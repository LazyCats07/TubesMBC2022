import psycopg2
from flask import jsonify,Flask,request
from datetime import datetime
from flask_restful import Resource, Api

app = Flask(__name__)
api = Api(app)
con = psycopg2.connect(         # buat connect ke database di postgre
        host = '192.168.0.101',
        port = '8888',
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
            _nama = request.form['nama'] #tinggal ganti nama colum 
            _panggil = request.form['panggil'] #tinggal ganti nama coloumn juga 
            _jeniskelamin = request.form['kelamin']
            _jurusan = request.form['jurusan']
            _angkatan = request.form['angkatan']
            _divisi = request.form['divisi']
            _status = request.form['status']
            _banyakprojek = request.form['project']
            _skill = request.form['skill']
            create_value = """INSERT INTO datafix (nama,panggil,kelamin,jurusan,angkatan,divisi,status,project,skill) VALUES(%s,%s,%s,%s,%s,%s,%s,%s,%s)"""
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
            _nama = request.form['nama'] 
            _posisi = request.form['posisi'] 
            _kode = request.form['kode']
            _nip = request.form['nip']
            _email = request.form['email']
            create_value = """INSERT INTO pembina (nama,posisi,kode,nip,email) VALUES(%s,%s,%s,%s,%s)"""
            sql.execute(create_value,(_nama,_posisi,_kode,_nip,_email))
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

    def post(self) : 
        try :
            sql = con.cursor()
            _nama = request.form['nama'] 
            _skill = request.form['skill'] 
            create_value = """INSERT INTO skill (nama,skill) VALUES(%s,%s)"""
            sql.execute(create_value,(_nama,_skill))
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


@app.route('/')
def home():
    return '<h1>Tubes MBC</h1><br>Link Data Asisten dan Caas : tambahin /profil<br>Link Data Pembina Lab : tambahin /dosen<br>Link Skill : tambahin /skill'

api.add_resource(profil,"/profil",endpoint = "profil", methods=['GET','POST'])
api.add_resource(dosen,"/dosen",endpoint = "dosen", methods=['GET','POST'])
api.add_resource(skill,"/skill",endpoint = "skill", methods=['GET','POST'])
# app.run(host = "192.168.233.223", port = "5000")

if __name__ == "__main__":
    app.run(debug=True, host = "192.168.0.101", port = "5000")