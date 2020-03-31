from app import db


class BaseEntidadService:

    session = db.session
    Entidad = object

    def __init__(self, session=None):
        if session is not None:
            self.session = session

    def get_all(self):
        return self.session.query(self.Entidad).all()

    def get(self, id):
        entidad = self.session.query(self.Entidad).filter_by(id=id).one()
        return entidad

    def get_query(self):
        return self.session.query(self.Entidad)

    def delete(self, id):
        entidad = self.session.query(self.Entidad).filter_by(id=id).one()
        self.session.delete(entidad)
        self.session.commit()

    def create(self, data):
        entidad = self.create_entity(data)
        self.session.add(entidad)
        self.session.commit()
        return entidad

    def update(self, id, data):
        entidad = self.update_entity(id, data)
        self.session.commit()
        return entidad

    def create_entity(self, data):
        raise NotImplementedError

    def update_entity(self, id, data):
        raise NotImplementedError
