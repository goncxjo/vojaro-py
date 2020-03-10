$ python -m venv venv

-- Linux
$ source venv/bin/activate
-- Windows
> venv\Scripts\activate

$ pip install -r requirements.txt

$ docker run --name vojaro-db \
    -p 5432:5432 \
    -e POSTGRES_DB=vojaro \
    -e POSTGRES_PASSWORD=v0j4r0 \
    -d postgres

$ flask db init & flask db migrate & flask db upgrade

$ curl -X POST -H 'Content-Type: application/json' -d '{
  "codigo": "UNDAV",
  "nombre": "Universidad Nacional de Avellaneda"
}' http://localhost:5000/api/universidades