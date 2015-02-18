import traceback

from zope import interface

from models import base
from models import user as user_data
from services import core
from _thrift.services.user import User
from _thrift.services.user import ttypes as user_types


class Service(core.ServiceHandler):

    interface.implements(User.Iface)

    @classmethod
    def service_name(cls):
        return "User.v1"

    @classmethod
    def processor(cls):
        return User.Processor

    def get(self, username):
        print "Retrieving user with username: %s" % username
        user = base.Session.query(
            user_data.User
        ).filter_by(
            username=username
        ).first()
        if user is not None:
            user_model = user_types.UserModel(
                user_id=user.id,
                username=user.username,
                password=user.password
            )
            print "Found user. Returning: %s" % user_model
            return user_model
        print "Couldn't find user."
        return user_types.UserModel(user_id=0)

    def remove(self, user_id):
        try:
            user = base.Session.query(
                user_data.User
            ).filter_by(id=user_id).first()
            base.Session.delete(user)
            print "Successfully removed user with id: %s" % user_id
            return True
        except Exception:
            print "An error occurred removing the user: %s" % user_id
            print traceback.format_exc()
            return False

    def create(self, username, password):
        print "Creating user with: %s:%s" % (username, password)
        user = user_data.User(
            username=username,
            password=password
        )
        try:
            base.Session.add(user)
            base.Session.flush()
            user_model = user_types.UserModel(
                user_id=user.id,
                username=user.username,
                password=user.password
            )
            print "Successfully created user: %s" % user_model
            return user_model
        except Exception:
            print "An error occurred creating user with %s:%s" % (
                username, password
            )
            print traceback.format_exc()
            return user_types.UserModel(user_id=0)

    def login(self, username, password):
        print "Attempting login with: %s:%s" % (username, password)
        user = base.Session.query(
            user_data.User
        ).filter_by(
            username=username
        ).first()
        print "Found user: %s" % user
        if user is not None:
            return user.password == password
        return False