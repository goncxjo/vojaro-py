from app import db

from .universidad import UniversidadRepository
from .departamento import DepartamentoRepository

universidad_repository = UniversidadRepository()
departamento_repository = DepartamentoRepository()


def save_changes():
    db.session.commit()
    # db.session.close()
