from flask import Flask,request,render_template
from flask import request
import data_pembimbing as dt
import loadjsoncaas as lj
import pickle
import numpy as np


app = Flask(__name__)
model = pickle.load(open('dataset.pkl','rb'))
simi = pickle.load(open('similarity.pkl','rb'))
ml_list = np.array(model['Skill'])
@app.route('/mlnya',methods=['POST'])
def recomen(skill):
     index = model[model['title'] == skill].index[0]
     distances = sorted(list(enumerate(simi[index])), reverse=True, key=lambda x: x[1])
     l=[]
     for i in distances[1:6]:
          l.append("{}".format(model.iloc[i[0]].title))
     return(1)
 
@app.route('/data')
def caas():
    return lj.g
@app.route('/pembimbing')
def pembimbing(): 
    return dt.obj


if __name__ == '__main__':
    app.run(debug=True)
