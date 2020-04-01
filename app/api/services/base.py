from app import db


class BaseEntidadService:

    session = db.session
    Entidad = None
    sortable_columns = dict()

    def __init__(self, session=None):
        if session is not None:
            self.session = session

    def query(self):
        if self.Entidad is None:
            raise NotImplementedError
        return self.session.query(self.Entidad)

    def get_all(self):
        return self.query().all()

    def get_paginated(self, page=1, per_page=9999, filters=None, sort=None):
        entities = self.query()
        query = self.apply_filters(entities, filters)
        query = self.apply_sort(query, sort)
        pagination = query.paginate(error_out=False, page=page, per_page=per_page)
        return pagination

    def apply_sort(self, query, sort):
        if sort is not None:
            sortable_columns = self.get_sortable_columns(sort)
            columns = sortable_columns.keys()
            if columns:
                columns_order = list(map(lambda x: '{} {}'.format(x, sort[x]), columns))
                query = query.sort(columns_order=columns_order)

        return query

    def get_sortable_columns(self, sort):
        columns = {}
        for key in sort.keys():
            if key in self.sortable_columns and (sort[key] != 'asc' or sort[key] != 'desc'):
                column = self.sortable_columns[key]
                columns[column] = sort[key]
        return columns

    def get(self, id):
        entidad = self.query()\
            .filter_by(id=id)\
            .one()

        return entidad

    def delete(self, id):
        entidad = self.query()\
            .filter_by(id=id)\
            .one()

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

    def apply_filters(self, query, filters):
        raise NotImplementedError

    def create_entity(self, data):
        raise NotImplementedError

    def update_entity(self, id, data):
        raise NotImplementedError
