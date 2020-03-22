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
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Llamadas.Add(llamada) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
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
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM LlamadaDetalle Where LlamadaId = {llamada.Llamadaid}");
               foreach (var item in llamada.Telefono)
                {
                   db.Entry(item).State = EntityState.Added;
                }
                db.Entry(llamada).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

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
            bool paso = false;
            Contexto db = new Contexto();
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
            Llamadas llamada = new Llamadas();
            Contexto db = new Contexto();
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



