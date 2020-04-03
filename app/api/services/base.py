from app.api.repositories.base import BaseEntityRepository


class BaseEntityService:
    repository: BaseEntityRepository = None

    def get_all(self):
        return self.repository.get_all()

    def get(self, id):
        return self.repository.get(id)

    def delete(self, id):
        self.repository.delete(id)

    def add(self, data):
        entity = self.add_entity(data)
        return self.repository.add(entity)

    def update(self, id, data):
        entity = self.update_entity(id, data)
        return entity

    def get_paginated(self, page=1, per_page=9999, filters=None, sort=None):
        return self.repository.get_paginated(page, per_page, filters, sort)

    def add_entity(self, data):
        raise NotImplementedError

    def update_entity(self, id, data):
        raise NotImplementedError
