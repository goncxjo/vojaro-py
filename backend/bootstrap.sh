#!/bin/bash
export FLASK_APP=vojaro.py
source $(pipenv --venv)/bin/activate
flask run