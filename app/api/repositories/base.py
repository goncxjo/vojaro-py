from app import db


class AbstractRepository:
    def get_all(self):
        raise NotImplementedError

    def get(self, id):
        raise NotImplementedError

    def delete(self, id):
        raise NotImplementedError

    def add(self, data):
        raise NotImplementedError

    def update(self, id, data):
        raise NotImplementedError


class BaseEntityRepository(AbstractRepository):

    session = db.session
    Entity: db.Model = None

    def initialize(self, session):
        self.session = session

    def query(self):
        return self.session.query(self.Entity)

    def get_all(self):
        return self.query().all()

    def get(self, id):
        entity = self.query()\
            .filter_by(id=id)\
            .one()

        return entity

    def delete(self, id):
        entity = self.query()\
            .filter_by(id=id)\
            .one()

        self.session.delete(entity)
        self.session.commit()

    def add(self, data):
        entity = self.add_entity(data)
        self.session.add(entity)
        self.session.commit()
        return entity

    def update(self, id, data):
        entity = self.update_entity(id, data)
        self.session.commit()
        return entity

    def add_entity(self, data):
        raise NotImplementedError

    def update_entity(self, id, data):
        raise NotImplementedError
