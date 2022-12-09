from flask import Flask
from flask import render_template,flash
# import data
# import asistenlab
# import requests 
# import database
# from flask_sqlalchemy import SQLAlchemy

#Buat masang Database.
# app = Flask(__name__)
# app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:password@localhost/tubesmbc'
# app.config["SQLALCHEMY_TRACK_MODIFICATIONS"] = False
# app.secret_key = 'secret string'
# db = SQLAlchemy(app)


#Buat Route Doang.
app = Flask(__name__)
# @app.route("/profil")
# def hello(): 
#     return data.obj

# @app.route("/Asisten")
# def asisten():
#     return asistenlab.data

@app.route("/dana")
def database():
    with open('DataAnakMBC.json', 'r') as f:
        return f.read()
