using Inventory.Models;
using Inventory.ViewModel.Bill;
using Inventory.ViewModel.Customer;
using Inventory.ViewModel.Invoice;
using Inventory.ViewModel.Payment;
using Inventory.ViewModel.Product;
using Inventory.ViewModel.Purchase;
using Inventory.ViewModel.Sales;
using Inventory.ViewModel.Shipment;
using Inventory.ViewModel.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.ViewModel.Mapping
{
    public static class RelationShip
    {
        public static IEnumerable <CustomerTypeListViewModel> ModelToVM(this IEnumerable<CustomerType> customerType)
        {
            List<CustomerTypeListViewModel> list = new List<CustomerTypeListViewModel>();
            foreach (var ct in customerType)
            {
                list.Add(new CustomerTypeListViewModel(ct)
                {
                    CustomerTypeId = ct.CustomerTypeId,
                    CustomerTypeName = ct.CustomerTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<CustomerViewModel> ModelToVM(this IEnumerable<Inventory.Models.Customer> customers)
        {
            List<CustomerViewModel> list = new List<CustomerViewModel>();
            foreach (var ct in customers)
            {
                list.Add(new CustomerViewModel(ct)
                {
                    CustomerId = ct.CustomerId,
                    CustomerName = ct.CustomerName,
                    City = ct.City,
                    ContactPerson = ct.ContactPerson,
                    CustomerTypeId = ct.CustomerTypeId,
                    ZipCode = ct.ZipCode,
                    Address = ct.Address,
                    Email = ct.Email,
                    Phone = ct.Phone,
                    State = ct.State
                });
            }
            return list;
        }

        public static IEnumerable<BillTypeListViewModel> ModelToVM(this IEnumerable<BillType> billTypes)
        {
            List<BillTypeListViewModel> list = new List<BillTypeListViewModel>();
            foreach (var ct in billTypes)
            {
                list.Add(new BillTypeListViewModel()
                {
                   BillTypeId = ct.BillTypeId,
                   BillTypeName = ct.BillTypeName,
                   Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<BillListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Bill> bills)
        {
            List<BillListViewModel> list = new List<BillListViewModel>();
            foreach (var ct in bills)
            {
                list.Add(new BillListViewModel()
                {
                    BillDate = ct.BillDate,
                    BillDueDate = ct.BillDueDate,
                    BillId = ct.BillId,
                    BillName = ct.BillName,
                    BillTypeId= ct.BillTypeId,
                    GoodsReceivedNoteId = ct.GoodsReceivedNoteId,
                    VendorDoNumber = ct.VendorDoNumber,
                    VendorInvoiceNumber = ct.VendorInvoiceNumber,


                });
            }
            return list;
        }

        public static IEnumerable<ProductTypeListViewModel> ModelToVM(this IEnumerable<ProductType> productTypes)
        {
            List<ProductTypeListViewModel> list = new List<ProductTypeListViewModel>();
            foreach (var ct in productTypes)
            {
                list.Add(new ProductTypeListViewModel(ct)
                {
                    ProductTypeId= ct.ProductTypeId,
                    ProductTypeName= ct.ProductTypeName,
                    Description= ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<ProductListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Product> products)
        {
            List<ProductListViewModel> list = new List<ProductListViewModel>();
            foreach (var ct in products)
            {
                list.Add(new ProductListViewModel()
                {
                    ProductId= ct.ProductId,
                    ProductName= ct.ProductName,
                    ProductCode= ct.ProductCode,
                    BarCode= ct.BarCode,
                    Description= ct.Description,
                    ProductImage= ct.ProductImage,
                    ProductType= ct.ProductType,
                    MeasureUnitId= ct.MeasureUnitId,
                    BuyingPrice= ct.BuyingPrice,
                    SellingPrice= ct.SellingPrice,
                    BranchId= ct.BranchId,
                    CurrencyId= ct.CurrencyId,
                });
            }
            return list;
        }

        public static IEnumerable<VendorTypeListViewModel> ModelToVM(this IEnumerable<VendorType> vendorTypes)
        {
            List<VendorTypeListViewModel> list = new List<VendorTypeListViewModel>();
            foreach (var ct in vendorTypes)
            {
                list.Add(new VendorTypeListViewModel(ct)
                {
                    VendorTypeId = ct.VendorTypeId,
                    VendorTypeName = ct.VendorTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<VendorListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Vendor> vendors)
        {
            List<VendorListViewModel> list = new List<VendorListViewModel>();
            foreach (var ct in vendors)
            {
                list.Add(new VendorListViewModel()
                {
                   VendorId = ct.VendorId,
                   VendorName = ct.VendorName,
                   VendorTypeId= ct.VendorTypeId,
                   Address = ct.Address,
                   City = ct.City,
                   State = ct.State,
                   ZipCode = ct.ZipCode,
                   Phone = ct.Phone,
                   Email = ct.Email,
                   ContactPerson = ct.ContactPerson,
                });
            }
            return list;
        }

        public static IEnumerable<SaleTypeListViewModel> ModelToVM(this IEnumerable<SalesType> salesTypes)
        {
            List<SaleTypeListViewModel> list = new List<SaleTypeListViewModel>();
            foreach (var ct in salesTypes)
            {
                list.Add(new SaleTypeListViewModel(ct)
                {
                    SalesTypeId = ct.SalesTypeId,
                    SalesTypeName = ct.SalesTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceTypeListViewModel> ModelToVM(this IEnumerable<InvoiceType> invoiceTypes)
        {
            List<InvoiceTypeListViewModel> list = new List<InvoiceTypeListViewModel>();
            foreach (var ct in invoiceTypes)
            {
                list.Add(new InvoiceTypeListViewModel(ct)
                {
                   InvoiceTypeId = ct.InvoiceTypeId,
                    InvoiceTypeName = ct.InvoiceTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<InvoiceListViewModel> ModelToVM(this IEnumerable<Inventory.Models.Invoice> invoices)
        {
            List<InvoiceListViewModel> list = new List<InvoiceListViewModel>();
            foreach (var ct in invoices)
            {
                list.Add(new InvoiceListViewModel()
                {
                    InvoiceId = ct.InvoiceId,
                    InvoiceName = ct.InvoiceName,
                    ShipmentId = ct.ShipmentId,
                    InvoiceDate = ct.InvoiceDate,
                    InvoiceDueDate = ct.InvoiceDueDate,
                    InvoiceTypeId = ct.InvoiceTypeId,
                });
            }
            return list;
        }

        public static IEnumerable<PaymentTypeListViewModel> ModelToVM(this IEnumerable<PaymentType> paymentTypes)
        {
            List<PaymentTypeListViewModel> list = new List<PaymentTypeListViewModel>();
            foreach (var ct in paymentTypes)
            {
                list.Add(new PaymentTypeListViewModel(ct)
                {
                    PaymentTypeId = ct.PaymentTypeId,
                    PaymentTypeName = ct.PaymentTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<PurchaseTypeListViewModel> ModelToVM(this IEnumerable<PurchaseType> purchaseTypes)
        {
            List<PurchaseTypeListViewModel> list = new List<PurchaseTypeListViewModel>();
            foreach (var ct in purchaseTypes)
            {
                list.Add(new PurchaseTypeListViewModel(ct)
                {
                    PurchaseTypeId = ct.PurchaseTypeId,
                    PurchaseTypeName = ct.PurchaseTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }

        public static IEnumerable<ShipmentTypeListViewModel> ModelToVM(this IEnumerable<ShipmentType> shipmentType)
        {
            List<ShipmentTypeListViewModel> list = new List<ShipmentTypeListViewModel>();
            foreach (var ct in shipmentType)
            {
                list.Add(new ShipmentTypeListViewModel(ct)
                {
                    ShipmentTypeId = ct.ShipmentTypeId,
                    ShipmentTypeName = ct.ShipmentTypeName,
                    Description = ct.Description,
                });
            }
            return list;
        }



    }
}
