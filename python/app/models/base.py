# ideally, you'd be implementing a DB solution that doesn't block
#   Twisted's main thread.

import sqlalchemy
from sqlalchemy.ext import declarative
from sqlalchemy.orm import sessionmaker, scoped_session


engine = sqlalchemy.create_engine(
    'sqlite:////tmp/unity3d-thrift-twisted.sqlite',
    connect_args={
        "check_same_thread": False
    }
)

session_factory = sessionmaker(bind=engine)
Session = scoped_session(session_factory)
ModelBase = declarative.declarative_base()


def setup_db():
    ModelBase.metadata.create_all(bind=engine)