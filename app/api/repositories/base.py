from app import db


class AbstractRepository:
    def get_all(self):
        raise NotImplementedError

    def get(self, id):
        raise NotImplementedError

    def delete(self, id):
        raise NotImplementedError

    def add(self, entity):
        raise NotImplementedError


class BaseEntityRepository(AbstractRepository):

    session = db.session
    Entity: db.Model = None
    sortable_columns = dict()

    def initialize(self, session):
        self.session = session

    def get_all(self):
        return self.session.query(self.Entity).all()

    def get(self, id):
        entity = self.session.query(self.Entity)\
            .filter_by(id=id)\
            .one()

        return entity

    def delete(self, id):
        entity = self.session.query(self.Entity)\
            .filter_by(id=id)\
            .one()

        self.session.delete(entity)

    def add(self, entity):
        self.session.add(entity)
        return entity

    def get_paginated(self, page=1, per_page=9999, filters=None, sort=None):
        entities = self.session.query(self.Entity)
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

    def apply_filters(self, query, filters):
        raise NotImplementedError
