using Microsoft.EntityFrameworkCore;
using SegParcial.DAL;
using SegParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SegParcial.BLL
{
    public class LlamadaBLL
    {
        public static bool Guargar(Llamadas llamada)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Llamadas.Add(llamada) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception){
                throw;
            }
            finally
            {
                db.Dispose();
                   
            }
            return paso;

        }
        public static bool Modificar(Llamadas llamada)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                db.Entry(llamada).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                var eliminar = LlamadaBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return paso;
        }
        public static Llamadas Buscar(int id)
        {
            Contexto db = new Contexto();
            Llamadas llamada = new Llamadas();
            try
            {
                llamada = db.Llamadas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();

            }
            return llamada;
        }
       

    }

    }



