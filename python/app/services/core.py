class ServiceHandler(object):

    @classmethod
    def service_name(cls):
        raise NotImplementedError("Sub-class must implement service_name.")

    @classmethod
    def processor(cls):
        raise NotImplementedError("Sub-class must implement processor.")


__all__ = ["ServiceHandler"]
