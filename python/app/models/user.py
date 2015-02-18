import sqlalchemy

from models import base


class User(base.ModelBase):

    __tablename__ = "users"

    id = sqlalchemy.Column(sqlalchemy.Integer, primary_key=True)
    username = sqlalchemy.Column(sqlalchemy.String)
    password = sqlalchemy.Column(sqlalchemy.String)

    def __repr__(self):
        repr_str = "<User(id='%s', username='%s', password='%s')>" % (
            self.id,
            self.username,
            self.password
        )
        return repr_str