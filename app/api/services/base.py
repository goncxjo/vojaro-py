from app.api.repositories.base import BaseEntityRepository


class BaseEntityService:
    repository: BaseEntityRepository = None
    sortable_columns = dict()

    def get_all(self):
        return self.repository.get_all()

    def get(self, id):
        return self.repository.get(id)

    def delete(self, id):
        self.repository.delete(id)

    def add(self, data):
        return self.repository.add(data)

    def update(self, id, data):
        return self.repository.update(id, data)

    def get_paginated(self, page=1, per_page=9999, filters=None, sort=None):
        entities = self.repository.query()
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
