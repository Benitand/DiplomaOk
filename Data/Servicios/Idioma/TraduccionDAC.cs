﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Data
{
    public class TraduccionDAC : DataAccessComponent, IRepository2<Traduccion>

    {
        public Traduccion ALoad(IDataReader entity)
        {

            Traduccion palabra = new Traduccion();
            palabra.idioma.Id = GetDataValue<int>(entity, "Id_idioma");
            palabra.palabra.Id = GetDataValue<int>(entity, "ID_Palabra");
            palabra.traduccion = GetDataValue<string>(entity, "palabra");
            return palabra;
        }

        public Traduccion Create(Traduccion entity)
        {
            const string SQL_STATEMENT = "insert into Traduccion(Id_idioma,ID_Palabra,palabra,activo)values(@Id_idioma,@ID_Palabra,@palabra,1)";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id_idioma", DbType.Int32, entity.idioma.idioma);
                db.AddInParameter(cmd, "@ID_Palabra", DbType.Int32, entity.palabra.Id);
                db.AddInParameter(cmd, "@palabra", DbType.String, entity.traduccion);

                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "Delete Traduccion  where id_palabra=@Id and ID_idioma=@idioma and palabra=@palabra";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.AddInParameter(cmd, "@Id", DbType.String, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(Traduccion entity )
        {
            const string SQL_STATEMENT = "Delete Traduccion  where id_palabra=@Id and ID_idioma=@idioma and palabra=@palabra";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.palabra.Id);

                db.AddInParameter(cmd, "@idioma", DbType.Int32, entity.idioma.Id);
                db.AddInParameter(cmd, "@palabra", DbType.String, entity.traduccion);
                db.ExecuteNonQuery(cmd);
            }
        }
        public List<Traduccion> Read()
        {
            const string SQL_STATEMENT = "select * from Traduccion";

            List<Traduccion> result = new List<Traduccion>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Traduccion roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;
        }

        public Traduccion ReadBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Traduccion> ReadByIdioma(int id)
        {


            const string SQL_STATEMENT = "select * from Traduccion where   id_idioma=@Id";
            List<Traduccion> result = new List<Traduccion>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Traduccion roles = ALoad(dr);
                        result.Add(roles);
                    }
                }
            }
            return result;

           
        }

       

        public void Update(Traduccion entity)
        {

            const string SQL_STATEMENT = "update Traduccion set Palabra=@Palabra where id_Palabra=@id and id_idioma=@id_idioma ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Palabra", DbType.String, entity.palabra);
                db.AddInParameter(cmd, "@id", DbType.Int32, entity.palabra.Id);
                db.AddInParameter(cmd, "@id_idioma", DbType.Int32, entity.idioma.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
