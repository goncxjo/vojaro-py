# TODO: ver porquè no funciona en los Models de SQLAlchemy
from flask_sqlalchemy import BaseQuery
from sqlalchemy import text


class EntityQuery(BaseQuery):
    def sort(self, **kwargs):
        columns_order = kwargs.pop('columns_order', '')
        if columns_order:
            order = text(''.join(columns_order))
            return self.order_by(order)
        else:
            return self
