from flask import Flask,request,render_template
from flask import request
import data_pembimbing as dt
import loadjsoncaas as lj
import pickle
import numpy as np
import streamlit as st
import pandas as pd

app = Flask(__name__)
model = pickle.load(open('dataset.pkl','rb'))
simi = pickle.load(open('similarity.pkl','rb'))
ml_list = np.array(model['Skill'])
option = st.selectbox("Input Skill : ",(ml_list))

@app.route('/mlnya',methods=['POST','GET'])
def recomen(skill):
    st.table(df) 
    index = model[model['title'] == skill].index[0]
    distances = sorted(list(enumerate(simi[index])), reverse=True, key=lambda x: x[1])
    l=[]
    for i in distances[1:6]:
        l.append("{}".format(model.iloc[i[0]].title))
    return(1)

if st.button('Rekomendasi Asisten'):
    st.write('Skill terkait : ')
    # st.write(movie_recommend(option),show_url(option))
    df = pd.DataFrame({
        'Asisten terkait skill': recomen(option)
    })

@app.route('/data')
def caas():
    return lj.g
@app.route('/pembimbing')
def pembimbing(): 
    return dt.obj

if __name__ == '__main__':
    app.run(host = '192.168.0.101', port = 5000, debug=True)