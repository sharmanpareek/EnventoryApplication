using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_DATA.Core;
using IOC_SERVICE.IService;
using IOC_SERVICE.Data;
using IOC_DATA;
using AutoMapper;

namespace IOC_SERVICE.Service
{
    public class PurchaseService : IPurchaseService
    {
        IPurchaseRepository _purchaseRepository;
        IPurchaseDetailRepository _purchaseDetailRepository;
        private DatabaseContext db = new DatabaseContext();

        public PurchaseService(IPurchaseRepository purchaseRepository, IPurchaseDetailRepository purchaseDetailRepository)
        {
            _purchaseRepository = purchaseRepository;
            _purchaseDetailRepository = purchaseDetailRepository;
        }
        public void Delete(PurchaseModel purchasemodel)
        {
            throw new NotImplementedException();
        }

        public void Edit(PurchaseModel purchasemodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PurchaseModel purchasemodel)
        {
            throw new NotImplementedException();
        }

        public PurchaseModel savePurchaseDetails(PurchaseViewModel purchaseviewmodel)
        {
            Mapper.Initialize(a => { a.CreateMap<PurchaseViewModel, Purchase>(); });
            var purchaseData = Mapper.Map<Purchase>(purchaseviewmodel);
            Purchase purchase = _purchaseRepository.Insert(purchaseData);

            Mapper.Initialize(a => { a.CreateMap<PurchaseDetailViewModel, PurchaseDetail>(); });
            var purchaseDetailList = Mapper.Map<List<PurchaseDetail>>(purchaseviewmodel.purchasedetaillist);
            foreach (var purchaseDetailData in purchaseDetailList)
            {
                purchaseDetailData.PurchaseId = purchase.PurchaseId;
                _purchaseDetailRepository.Insert(purchaseDetailData);
            }
            return null;
        }

        public List<PurchaseViewModel> purchaseViewDetail(int userId)
        {
            var purchaseDetailData = (from purchaseData in db.purchase
                                      join partytype in db.partytype on purchaseData.PartyId equals partytype.PartyId
                                      where purchaseData.UserId == userId && purchaseData.IsDeleted==false
                                      select new PurchaseViewModel
                                      {
                                          PurchaseId = purchaseData.PurchaseId,
                                          PartyName = partytype.PartyName,
                                          GrandTotal = purchaseData.GrandTotal,
                                          InvoiceNumber = purchaseData.InvoiceNumber,
                                      }).ToList();
            return purchaseDetailData;
        }

        public PurchaseViewModel billDetail(int purchaseid)
        {
            var BillData = (from purchaseData in db.purchase
                            join partytype in db.partytype on purchaseData.PartyId equals partytype.PartyId
                            join taxtype in db.taxtype on purchaseData.TaxId equals taxtype.TaxId
                            where purchaseData.PurchaseId == purchaseid
                            select new PurchaseViewModel
                            {
                                InvoiceNumber = purchaseData.InvoiceNumber,
                                GrandTotal = purchaseData.GrandTotal,
                                PurchaseDate = purchaseData.PurchaseDate,
                                PartyId = partytype.PartyId,
                                PartyName = partytype.PartyName,
                                TaxId = taxtype.TaxId,
                                TaxRate = taxtype.TaxRate,
                                Total = purchaseData.Total,
                                Contact=partytype.Contact,
                                Address=partytype.Address
                                
                            }).SingleOrDefault();

            var BillDetailList = (from purchaseDetail in db.purchasedetail
                                  join purchasetype in db.purchase on purchaseDetail.PurchaseId equals purchasetype.PurchaseId
                                  join itemtype in db.itemtype on purchaseDetail.ItemId equals itemtype.ItemId
                                  where purchasetype.PurchaseId == purchaseid
                                  select new PurchaseDetailViewModel
                                  {
                                      PurchaseDetailId=purchaseDetail.PurchaseDetailId,
                                      PurchaseUnit=purchaseDetail.PurchaseUnit,
                                      UnitPrice=purchaseDetail.UnitPrice,
                                      SubTotal=purchaseDetail.SubTotal,
                                      ItemName=itemtype.ItemName,
                                      ItemId=itemtype.ItemId
                                  }).ToList();

            BillData.purchasedetaillist = BillDetailList;
            return BillData;
        }

        public bool cancelbill(PurchaseModel purchasemodel)
        {
            Mapper.Initialize(a => { a.CreateMap<PurchaseModel, Purchase>(); });
            var billData = Mapper.Map<Purchase>(purchasemodel);
            return _purchaseRepository.CancelBill(billData);
        }

        public List<PurchaseViewModel> GetpurchaseViewDetail()
        {
            var data = (from purchaseData in db.purchase
                        join usertype in db.user on purchaseData.UserId equals usertype.UserId
                        join partytype in db.partytype on purchaseData.PartyId equals partytype.PartyId
                        select new PurchaseViewModel
                        {
                            PartyId = partytype.PartyId,
                            PartyName = partytype.PartyName,
                            UserId = usertype.UserId,
                            FirstName = usertype.FirstName,
                            InvoiceNumber = purchaseData.InvoiceNumber,
                            GrandTotal = purchaseData.GrandTotal,
                            PurchaseId=purchaseData.PurchaseId,

                        }).ToList();
            return data;
        }
    }
}
