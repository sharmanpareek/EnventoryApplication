using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using IOC_REPOSITORY.IRepository;
using AutoMapper;
using IOC_DATA.Core;
using IOC_DATA;

namespace IOC_SERVICE.Service
{
  public  class SaleService : ISaleService
    {
        ISaleRepository _iSaleRepository;
        ISaleDetailRepository _iSaleDetailRepository;
        private DatabaseContext db = new DatabaseContext();

        public SaleService(ISaleRepository iSaleRepository, ISaleDetailRepository iSaleDetailRepository)
        {
            _iSaleRepository = iSaleRepository;
            _iSaleDetailRepository = iSaleDetailRepository;
        }
        public void Delete(SaleModel salemodel)
        {
            throw new NotImplementedException();
        }

        public void Edit(SaleModel salemodel)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSp()
        {
           int id= _iSaleRepository.ExecuteSp();
            return id;
        }

        public IEnumerable<SaleModel> GetAll()
        {

            var saleData = _iSaleRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<Sale, SaleModel>(); });
            var saleDetail = Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleModel>>(saleData);
            return saleDetail;
        }

        public SaleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SaleModel salemodel)
        {
            throw new NotImplementedException();
        }

        public SaleModel SaveSaleDetails( SaleViewModel saleviewmodel)
        {
            //Sale salemodel = new Sale();
            //SaleDetailModel saledetailmodel = new SaleDetailModel();
            //salemodel.BillNo = saleviewmodel.BillNo;
            //salemodel.PartyId = saleviewmodel.PartyId;
            //salemodel.CreatedDate = saleviewmodel.CreatedDate;
            //salemodel.Total = saleviewmodel.Total;
            //saleviewmodel.GrandTotal = saleviewmodel.GrandTotal;

            Mapper.Initialize(cfg => { cfg.CreateMap<SaleViewModel, Sale>(); });

            var item = Mapper.Map<Sale>(saleviewmodel);

             Sale sale=_iSaleRepository.Insert(item);

            Mapper.Initialize(cfg => { cfg.CreateMap<SaleDetailViewModel, SaleDetail>(); });

            var saleDetailList = Mapper.Map<List<SaleDetail>>(saleviewmodel.SaleDetailList);

            foreach(var saleDeatilData in saleDetailList)
            {
                saleDeatilData.SaleId = sale.SaleId;
                _iSaleDetailRepository.Insert(saleDeatilData);
            }
            

            return null;
        }

        public List<SaleViewModel> SaleDetail(int userId)
        {

            var data = (from saleData in db.sale
                        join partytype in db.partytype on saleData.PartyId equals partytype.PartyId
                        where saleData.UserId==userId
                        select new SaleViewModel
                        {
                            SaleId=saleData.SaleId,
                            PartyId = partytype.PartyId,
                            PartyName = partytype.PartyName,
                            BillNo=saleData.BillNo,
                            GrandTotal=saleData.GrandTotal
                        }).ToList();
            return data;
        }

        public SaleViewModel SaleBillDetail(int saleid)
        {
            var billData = (from saleData in db.sale
                            join partytype in db.partytype on saleData.PartyId equals partytype.PartyId
                            join taxtype in db.taxtype on saleData.TaxId equals taxtype.TaxId
                            where saleData.SaleId == saleid
                            select new SaleViewModel
                            {
                                BillNo = saleData.BillNo,
                                PartyId = partytype.PartyId,
                                PartyName = partytype.PartyName,
                                Address=partytype.Address,
                                Contact=partytype.Contact,
                                CreatedDate = saleData.CreatedDate,
                                GrandTotal = saleData.GrandTotal,
                                Total=saleData.Total,
                                TaxRate=taxtype.TaxRate,
                            }).SingleOrDefault();

            var itemData = (from saleDetail in db.saledetail
                            join saletype in db.sale on saleDetail.SaleId equals saletype.SaleId
                            join item in db.itemtype on saleDetail.ItemId equals item.ItemId
                            where saletype.SaleId == saleid
                            select new SaleDetailViewModel
                            {
                                SaleDetailId = saleDetail.SaleDetailId,
                                ItemId = saleDetail.ItemId,
                                ItemName = item.ItemName,
                                UnitPrice = saleDetail.UnitPrice,
                                UnitSold = saleDetail.UnitSold,
                                SubTotal=saleDetail.SubTotal,
                                

                            }).ToList();
            billData.SaleDetailList = itemData;
            return billData;
        }

        public List<SaleViewModel> GetSaleDetail()
        {
            var Data = (from saleData in db.sale
                        join partytype in db.partytype on saleData.PartyId equals partytype.PartyId
                        join usertype in db.user on saleData.UserId equals usertype.UserId
                        select new SaleViewModel
                        {
                            SaleId=saleData.SaleId,
                            PartyId = partytype.PartyId,
                            PartyName = partytype.PartyName,
                            UserId = usertype.UserId,
                            FirstName = usertype.FirstName,
                            BillNo = saleData.BillNo,
                            GrandTotal = saleData.GrandTotal,
                        }).ToList();
            return Data;
        }
    }
}
