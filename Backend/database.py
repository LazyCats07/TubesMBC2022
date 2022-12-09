import psycopg2
from flask import jsonify,Flask,request
from datetime import datetime
from flask_restful import Resource,Api

app = Flask(__name__)
api = Api(app)
con = psycopg2.connect(
                host = "192.168.18.11",
                database = "tubesmbcbaru", #Tinggal Ganti jadi TUBESMBC yang ada dipostgres
                user = "adamhadipratama7",
                password = "adamhadip",
)


class Mbc(Resource): 
    def get(self):
        try : 
            sql = con.cursor()
            sql.execute("""SELECT * FROM tubesmbc_baru""")
            asisten = sql.fetchall()
            result = jsonify(asistendancaas=asisten)
            result.status_code = 200
            return(result)
        except Exception as err : 
            print(err)
            result = jsonify("failed to fetch...")
            result.status_code = 400
            return(result)
        finally : 
            sql.close()
            
    def post(self) : 
        try :
            sql = con.cursor()
            _nama = request.form['name'] #tinggal ganti nama colum 
            _panggil = request.form['nama_panggil'] #tinggal ganti nama coloumn juga 
            _jeniskelamin = request.form['jenis_kelamin']
            _jurusan = request.form['jurusan']
            _angkatan = request.form['angkatan']
            _divisi = request.form['divisi']
            _status = request.form['status']
            _banyakprojek = request.form['banyak_project']
            _skill = request.form['skill']
            create_value = """INSERT INTO tubesmbc_baru (name,nama_panggil,Jenis_kelamin,jurusan,angkatan,divisi,status,banyak project,skill) VALUES(%s,%s)"""
            sql.execute(create_value,(_nama,_panggil,_jeniskelamin,_jurusan,_angkatan,_divisi,_status,_banyakprojek,_skill))
            con.commit()
            result = jsonify(data="User telah ditambahkan")
            result.status_code = 200
            return(result)
        except Exception as err : 
            print(err)
            result = jsonify(data="data gagal")
            result.status_code = 400
            return(result)
        finally : 
            sql.close()
                   
api.add_resource(Mbc,"/mbc",endpoint='mbc')
app.run(host = "192.168.18.11",port = "3200")