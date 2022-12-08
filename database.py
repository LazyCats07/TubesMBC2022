import psycopg2
import json
from datetime import datetime
def database_():
    con = psycopg2.connect(
                host = "127.0.0.1",
                database = "postgres",
                user = "adamhadipratama",
                password = "adamdvimprez7",
    )

    cur = con.cursor()

    cur.execute("SELECT row_to_json (dana_task) FROM dana_task")

    rows = cur.fetchall()

    for r in rows : 
        print (r)
database_()