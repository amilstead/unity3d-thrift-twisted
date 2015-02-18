import argparse

from twisted.internet import reactor
from twisted.internet import endpoints
from thrift import TMultiplexedProcessor
from thrift.transport import TTwisted
from thrift.protocol import TBinaryProtocol

import services
from models import base as model_base

default_port = 8001


def create_server(server_reactor, port):
    model_base.setup_db()

    mux = TMultiplexedProcessor.TMultiplexedProcessor()

    for service_name, service in services.handlers.iteritems():
        processor = service.processor()
        mux.registerProcessor(service_name, processor(service()))

    server_factory = TTwisted.ThriftServerFactory(
        processor=mux,
        iprot_factory=TBinaryProtocol.TBinaryProtocolFactory()
    )
    server_endpoint = endpoints.TCP4ServerEndpoint(server_reactor, port)
    server_endpoint.listen(server_factory)
    server_reactor.run()


if __name__ == "__main__":

    parser = argparse.ArgumentParser(description="Start Unity3D User Services.")
    parser.add_argument(
        "-p",
        "--port",
        dest="port",
        type=int,
        default=default_port,
        help="Port to listen"
    )

    args = parser.parse_args()
    create_server(reactor, args.port)