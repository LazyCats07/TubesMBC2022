from flask import Flask
import json

app = Flask(__name__)

@app.route('/data')
def dat():
  with open('data.json', 'r') as f:
    jsonData = json.loads(f.read())
    return jsonData