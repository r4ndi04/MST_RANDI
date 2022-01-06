using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MST_POS.Entities;
using MST_POS.Models;

namespace MST_POS.ModelClass
{
    public class KodePosClass
    {
        MSTEntities context = new MSTEntities();
        private IQueryable<tblPos> GetAllKodePos()
        {
            var allKodePos = context.tblPos;
            return allKodePos;
        }
        private tblPos GetSingleTblPos(int ID)
        {
            var tblPos = GetAllKodePos().SingleOrDefault(x => x.ID == ID);
            return tblPos;
        }
        public KodePosModel GetCreateKodePosModel()
        {
            var createKodePosModel = new KodePosModel();
            return createKodePosModel;
        }
        public List<KodePosModel> GetIndexKodePos(string searchpropinsi, string searchkabupaten)
        {
            var allKodePos = GetAllKodePos().Where(kodePos => kodePos.Propinsi.Contains(searchpropinsi) && kodePos.Kabupaten.Contains(searchkabupaten));
            var query = from pos in allKodePos
                        select new KodePosModel
                        {
                            ID = pos.ID,
                            NoKodePos = pos.NoKodePos,
                            Kelurahan = pos.Kelurahan,
                            Kecamatan = pos.Kecamatan,
                            Jenis = pos.Jenis,
                            Kabupaten = pos.Kabupaten,
                            Propinsi = pos.Propinsi
                        };
            return query.ToList();
        }
        public void CreateKodePos(KodePosModel model)
        {
            var kodePos = new tblPos();
            kodePos.NoKodePos = model.NoKodePos;
            kodePos.Kelurahan = model.Kelurahan;
            kodePos.Kecamatan = model.Kecamatan;
            kodePos.Jenis = model.Jenis;
            kodePos.Kabupaten = model.Kabupaten;
            kodePos.Propinsi = model.Propinsi;

            try
            {
                context.tblPos.Add(kodePos);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public KodePosModel GetEditKodePosModel(int ID)
        {
            var tblPosEntity = GetSingleTblPos(ID);
            var model = new KodePosModel();
            model.ID = tblPosEntity.ID;
            model.NoKodePos = tblPosEntity.NoKodePos;
            model.Kelurahan = tblPosEntity.Kelurahan;
            model.Kecamatan = tblPosEntity.Kecamatan;
            model.Jenis = tblPosEntity.Jenis;
            model.Kabupaten = tblPosEntity.Kabupaten;
            model.Propinsi = tblPosEntity.Propinsi;

            return model;
        }
        public void EditKodePos(KodePosModel model)
        {
            var tblPosEntity = GetSingleTblPos(model.ID);
            tblPosEntity.NoKodePos = model.NoKodePos;
            tblPosEntity.Kelurahan = model.Kelurahan;
            tblPosEntity.Kecamatan = model.Kecamatan;
            tblPosEntity.Jenis = model.Jenis;
            tblPosEntity.Kabupaten = model.Kabupaten;
            tblPosEntity.Propinsi = model.Propinsi;

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool DeleteKodePos(int ID)
        {
            var tblPosEntity = GetSingleTblPos(ID);

            try
            {
                context.tblPos.Remove(tblPosEntity);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}