from services.user import service as account_service


handlers = {
    account_service.Service.service_name(): account_service.Service
}


__all__ = ["handlers"]