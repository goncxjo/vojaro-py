#coding=utf-8

from .entities.entity import Session, engine, Base
from .entities.universidad import Universidad

# generate database schema
Base.metadata.create_all(engine)

# start session
session = Session()

# check for existing data
universidades = session.query(Universidad).all()

if len(universidades) == 0:
    # create and persis dummy universidad
    python_universidad = Universidad("UNDAV", "Universidad Nacional de Avellaneda", "script")
    session.add(python_universidad)
    session.commit()
    session.close()

    # reload universidades
    universidades = session.query(Universidad).all()

# show existing Universidades
print('### Universidades:')

for universidad in universidades:
    print(f'({universidad.id}) {universidad.codigo} - {universidad.nombre}')