#coding=utf-8

from app import app

from flask import render_template, jsonify, request

@app.route('/')
@app.route('/index')
def index():
    return render_template('index.html')

@app.route('/ping')
def ping():
    return 'Pong!'
