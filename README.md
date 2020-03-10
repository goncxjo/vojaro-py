On the root folder type:

`python -m venv venv`

### Linux/MAC
`source venv/bin/activate`
### Windows
`venv\Scripts\activate`

`pip install -r requirements.txt`

Run this if there is no database
`docker run --name vojaro-db \`
`    -p 5432:5432 \`
`    -e POSTGRES_DB=vojaro \`
`    -e POSTGRES_PASSWORD=v0j4r0 \`
`    -d postgres`

`flask db init`
`flask db migrate`
`flask db upgrade`

Run the app:
### Linux/MAC
`bootstrap.sh`
### Windows
`bootstrap.bat`

For testing the API
`curl -X POST -H 'Content-Type: application/json' -d '{`
`  "codigo": "UNDAV",`
`  "nombre": "Universidad Nacional de Avellaneda"`
`}' http://localhost:5000/api/universidades`
