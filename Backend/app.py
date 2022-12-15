import psycopg2
from flask import Flask,jsonify,request,render_template
from datetime import datetime
from flask_restful import Api,Resource,reqparse,abort

app = Flask(__name__)
api = Api(app)
con = psycopg2.connect(         # buat connect ke database di postgre
        host = "192.168.0.101",
        port = '5000',
        database = 'postgres',
        user = 'zaidan',
        password = 'zaidan123',
    )

class profil(Resource):
    def get(self): 
        try :
            sql = con.cursor()      # akses database yang udah tersambung dari postgre & nyimpen semua datanya
            sql.execute("""SELECT * FROM datafix""")
            call = sql.fetchall()      # ngambil semua hasil query data dan mengembalikannya kedalam bentuk tuple
            result = jsonify(profil=call)     # nyimpen data api kedalam json
            result.status_code = 200
            return(result)
        except Exception as err : 
            print(err)
            result = jsonify("gagal fetch")
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
            create_value = """INSERT INTO datafix (name,nama_panggil,Jenis_kelamin,jurusan,angkatan,divisi,status,banyak project,skill) VALUES(%s,%s)"""
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

class dosen(Resource):
    def get(self): 
        try :
            sql = con.cursor()
            sql.execute("""SELECT * FROM pembina""")
            call = sql.fetchall()
            result = jsonify(dosen=call)
            result.status_code = 200
            return(result)
        except Exception as err : 
            print(err)
            result = jsonify("gagal fetch")
            result.status_code = 400
            return(result)
        finally : 
            sql.close()
    
    def post(self) : 
        try :
            sql = con.cursor()
            _nama = request.form['nama'] #tinggal ganti nama colum 
            _divisipem = request.form['divisi'] #tinggal ganti nama coloumn juga 
            create_value = """INSERT INTO pembina (name,divisi) VALUES(%s,%s)"""
            sql.execute(create_value,(_nama,_divisipem))
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

class skill(Resource):
    def get(self): 
        try :
            sql = con.cursor()
            sql.execute("""SELECT * FROM skill""")
            call = sql.fetchall()
            result = jsonify(skill=call)
            result.status_code = 200
            return(result)
        except Exception as err : 
            print(err)
            result = jsonify("gagal fetch")
            result.status_code = 400
            return(result)
        finally : 
            sql.close()


@app.route('/')
def home():
    return '<h1>Tubes MBC</h1><br>Link Data Asisten dan Caas : tambahin /profil<br>Link Data Pembina Lab : tambahin /dosen'

api.add_resource(profil,"/profil",endpoint = "profil", methods=['GET'])
api.add_resource(dosen,"/dosen",endpoint = "dosen", methods=['GET'])
api.add_resource(skill,"/skill",endpoint = "skill", methods=['GET'])
app.run(host = "192.168.0.101", port = "5000")