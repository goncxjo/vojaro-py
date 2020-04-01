#!flask/bin/python
import json
from app.api.services.universidades import UniversidadService

undav = {'codigo': 'undav', 'nombre': 'universidad nacional de avellaneda'}
unaj = {'codigo': 'unaj', 'nombre': 'universidad nacional arturo jauretche'}
unq = {'codigo': 'unq', 'nombre': 'universidad nacional de quilmes'}
unla = {'codigo': 'unla', 'nombre': 'universidad nacional de lanus'}

data_undav = json.loads(json.dumps(undav))
data_unaj = json.loads(json.dumps(unaj))
data_unq = json.loads(json.dumps(unq))
data_unla = json.loads(json.dumps(unla))


def test_get_all(session):
    service = UniversidadService(session)

    service.create(data_undav)
    service.create(data_unaj)

    universidades = service.get_all()
    for u in universidades:
        assert u.id > 0


def test_post_model(session):
    service = UniversidadService(session)
    request = {'codigo': 'undav', 'nombre': 'universidad nacional de avellaneda', 'departamentos': []}
    data = json.loads(json.dumps(request))
    universidad = service.create(data)

    assert universidad.id > 0


def test_get_paginated_without_filtering_and_sorting(session):
    service = UniversidadService(session)

    service.create(data_undav)
    service.create(data_unaj)
    service.create(data_unq)
    service.create(data_unla)

    universidades = service.get_paginated(page=2, per_page=1)

    print('__')
    for u in universidades.items:
        print(u)

    for u in universidades.items:
        assert u.codigo == 'unaj'


def test_get_paginated_with_filtering(session):
    service = UniversidadService(session)

    service.create(data_undav)
    service.create(data_unaj)
    service.create(data_unq)
    service.create(data_unla)

    universidades = service.get_paginated(filters={'codigo': 'unla'})

    if universidades.total != 0:
        for u in universidades.items:
            assert u.codigo == 'unla'
    else:
        assert 1 == 0


def test_get_paginated_with_filtering_has_no_result(session):
    service = UniversidadService(session)

    service.create(data_undav)
    service.create(data_unaj)
    service.create(data_unq)
    service.create(data_unla)

    universidades = service.get_paginated(filters={'codigo': 'uba'})

    assert universidades.total == 0


def test_get_paginated_with_sortering(session):
    service = UniversidadService(session)

    service.create(data_undav)
    service.create(data_unaj)
    service.create(data_unq)
    service.create(data_unla)

    universidades = service.get_paginated(sort={'codigo': 'asc'})
    assert universidades.items[0].codigo == 'unaj'

    universidades = service.get_paginated(sort={'codigo': 'desc'})
    assert universidades.items[0].codigo == 'unq'
