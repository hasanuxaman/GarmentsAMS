using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    public partial class SQQEYEDbContext : DbContext
    {
        public SQQEYEDbContext()
            : base("name=SQQEYEDbContext")
        {
        }

        public virtual DbSet<AccountLead> AccountLeads { get; set; }
        public virtual DbSet<AirFreightDetail> AirFreightDetails { get; set; }
        public virtual DbSet<AirFreightFile> AirFreightFiles { get; set; }
        public virtual DbSet<AirFreightMaster> AirFreightMasters { get; set; }
        public virtual DbSet<AirFreightUserLog> AirFreightUserLogs { get; set; }
        public virtual DbSet<ArrivedVisitor> ArrivedVisitors { get; set; }
        public virtual DbSet<AssetCatagoryName> AssetCatagoryNames { get; set; }
        public virtual DbSet<Bill_Allocation> Bill_Allocation { get; set; }
        public virtual DbSet<Bill_AllocationDetails> Bill_AllocationDetails { get; set; }
        public virtual DbSet<Bill_AllocationMaster> Bill_AllocationMaster { get; set; }
        public virtual DbSet<Bill_ApproverMaster> Bill_ApproverMaster { get; set; }
        public virtual DbSet<Bill_BankDetails> Bill_BankDetails { get; set; }
        public virtual DbSet<Bill_ChequeInfo> Bill_ChequeInfo { get; set; }
        public virtual DbSet<Bill_DocumentCenter> Bill_DocumentCenter { get; set; }
        public virtual DbSet<Bill_FileTable> Bill_FileTable { get; set; }
        public virtual DbSet<Bill_GRNFileTable> Bill_GRNFileTable { get; set; }
        public virtual DbSet<Bill_InvoiceDetails> Bill_InvoiceDetails { get; set; }
        public virtual DbSet<Bill_InvoiceMaster> Bill_InvoiceMaster { get; set; }
        public virtual DbSet<Bill_InvoiceType> Bill_InvoiceType { get; set; }
        public virtual DbSet<Bill_LogInvoiceDetails> Bill_LogInvoiceDetails { get; set; }
        public virtual DbSet<Bill_LogTable> Bill_LogTable { get; set; }
        public virtual DbSet<Bill_PODetails> Bill_PODetails { get; set; }
        public virtual DbSet<Bill_PODetailsReplica> Bill_PODetailsReplica { get; set; }
        public virtual DbSet<Bill_PODetailsTemp> Bill_PODetailsTemp { get; set; }
        public virtual DbSet<Bill_POFileTable> Bill_POFileTable { get; set; }
        public virtual DbSet<Bill_POMaster> Bill_POMaster { get; set; }
        public virtual DbSet<Bill_ProcurementTable> Bill_ProcurementTable { get; set; }
        public virtual DbSet<Bill_PurchaseOrderDetails> Bill_PurchaseOrderDetails { get; set; }
        public virtual DbSet<Bill_PurchaseOrderMaster> Bill_PurchaseOrderMaster { get; set; }
        public virtual DbSet<Bill_Quality> Bill_Quality { get; set; }
        public virtual DbSet<Bill_QualityResult> Bill_QualityResult { get; set; }
        public virtual DbSet<Bill_SubCategory> Bill_SubCategory { get; set; }
        public virtual DbSet<Bill_Supplier> Bill_Supplier { get; set; }
        public virtual DbSet<Bill_TableApprover> Bill_TableApprover { get; set; }
        public virtual DbSet<Bill_Unit> Bill_Unit { get; set; }
        public virtual DbSet<Bill_UserWiseGl> Bill_UserWiseGl { get; set; }
        public virtual DbSet<Bill_UserWiseSupplier> Bill_UserWiseSupplier { get; set; }
        public virtual DbSet<BuWiseApproverTable> BuWiseApproverTables { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<CatagoryWiseAsset> CatagoryWiseAssets { get; set; }
        public virtual DbSet<ContainerSize> ContainerSizes { get; set; }
        public virtual DbSet<ContainerType> ContainerTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CourierDepartment> CourierDepartments { get; set; }
        public virtual DbSet<CourierDispatchMaster> CourierDispatchMasters { get; set; }
        public virtual DbSet<CourierLogTable> CourierLogTables { get; set; }
        public virtual DbSet<CourierReceivedTable> CourierReceivedTables { get; set; }
        public virtual DbSet<CourierRoleWiseApprover> CourierRoleWiseApprovers { get; set; }
        public virtual DbSet<CourierTableApprover> CourierTableApprovers { get; set; }
        public virtual DbSet<CurrencyValue> CurrencyValues { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }
        public virtual DbSet<DepartmentTableOperation> DepartmentTableOperations { get; set; }
        public virtual DbSet<Event_Register> Event_Register { get; set; }
        public virtual DbSet<EventTable> EventTables { get; set; }
        public virtual DbSet<ExceptionApproverMaster> ExceptionApproverMasters { get; set; }
        public virtual DbSet<ExceptionDetailsTable> ExceptionDetailsTables { get; set; }
        public virtual DbSet<ExceptionFileTable> ExceptionFileTables { get; set; }
        public virtual DbSet<ExceptionGenaralInformation> ExceptionGenaralInformations { get; set; }
        public virtual DbSet<ExceptionLogTable> ExceptionLogTables { get; set; }
        public virtual DbSet<ExceptionReasonTable> ExceptionReasonTables { get; set; }
        public virtual DbSet<ExceptionRequestHRLogTable> ExceptionRequestHRLogTables { get; set; }
        public virtual DbSet<ExceptionRequestHRReason> ExceptionRequestHRReasons { get; set; }
        public virtual DbSet<ExceptionRequestHRRoleWiseApprover> ExceptionRequestHRRoleWiseApprovers { get; set; }
        public virtual DbSet<ExceptionRequestHRTableApprover> ExceptionRequestHRTableApprovers { get; set; }
        public virtual DbSet<ExceptionRequestMaster> ExceptionRequestMasters { get; set; }
        public virtual DbSet<ExceptionTableApprover> ExceptionTableApprovers { get; set; }
        public virtual DbSet<Forwarder> Forwarders { get; set; }
        public virtual DbSet<ICUnit> ICUnits { get; set; }
        public virtual DbSet<ImportConsignmentDetail> ImportConsignmentDetails { get; set; }
        public virtual DbSet<ImportConsignmentFile> ImportConsignmentFiles { get; set; }
        public virtual DbSet<ImportConsignmentMaster> ImportConsignmentMasters { get; set; }
        public virtual DbSet<ImportConsignmentUserLog> ImportConsignmentUserLogs { get; set; }
        public virtual DbSet<IouAmmountTable> IouAmmountTables { get; set; }
        public virtual DbSet<IouDepartmentHeadTable> IouDepartmentHeadTables { get; set; }
        public virtual DbSet<IOuDisbarsementTable> IOuDisbarsementTables { get; set; }
        public virtual DbSet<IOUFileTable> IOUFileTables { get; set; }
        public virtual DbSet<IouLogTable> IouLogTables { get; set; }
        public virtual DbSet<IouMasterApproverTable> IouMasterApproverTables { get; set; }
        public virtual DbSet<IOUMasterRequestTable> IOUMasterRequestTables { get; set; }
        public virtual DbSet<IOUTableApprover> IOUTableApprovers { get; set; }
        public virtual DbSet<LocationTable> LocationTables { get; set; }
        public virtual DbSet<PermissionTable> PermissionTables { get; set; }
        public virtual DbSet<ProjectTable> ProjectTables { get; set; }
        public virtual DbSet<RateMatrix> RateMatrices { get; set; }
        public virtual DbSet<RequesterApproverPermission> RequesterApproverPermissions { get; set; }
        public virtual DbSet<RequestorMasterTable> RequestorMasterTables { get; set; }
        public virtual DbSet<RouteMaster> RouteMasters { get; set; }
        public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserWiseBuTable> UserWiseBuTables { get; set; }
        public virtual DbSet<UserWiseCatagory> UserWiseCatagories { get; set; }
        public virtual DbSet<UserWiseLocation> UserWiseLocations { get; set; }
        public virtual DbSet<VehicleAllocationDetail> VehicleAllocationDetails { get; set; }
        public virtual DbSet<VehicleAllocationMaster> VehicleAllocationMasters { get; set; }
        public virtual DbSet<VehicleApproverMaster> VehicleApproverMasters { get; set; }
        public virtual DbSet<VehicleLogTable> VehicleLogTables { get; set; }
        public virtual DbSet<VehicleRoleWiseApprover> VehicleRoleWiseApprovers { get; set; }
        public virtual DbSet<VehicleTableApprover> VehicleTableApprovers { get; set; }
        public virtual DbSet<VendorMaster> VendorMasters { get; set; }
        public virtual DbSet<VisitorApproverTable> VisitorApproverTables { get; set; }
        public virtual DbSet<VisitorCategory> VisitorCategories { get; set; }
        public virtual DbSet<VisitorDetailsTable> VisitorDetailsTables { get; set; }
        public virtual DbSet<VisitorLogTable> VisitorLogTables { get; set; }
        public virtual DbSet<VisitorMasterApproveTable> VisitorMasterApproveTables { get; set; }
        public virtual DbSet<VisitorRequestTable> VisitorRequestTables { get; set; }
        public virtual DbSet<VisitorRoleWiseApprover> VisitorRoleWiseApprovers { get; set; }
        public virtual DbSet<VisitorSubCategory> VisitorSubCategories { get; set; }
        public virtual DbSet<VisitorTableApprover> VisitorTableApprovers { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<ApproverTableList> ApproverTableLists { get; set; }
        public virtual DbSet<Bill_AllocationPODetails> Bill_AllocationPODetails { get; set; }
        public virtual DbSet<Bill_CommentsTable> Bill_CommentsTable { get; set; }
        public virtual DbSet<Bill_GlInfo> Bill_GlInfo { get; set; }
        public virtual DbSet<Bill_POMasterReplica> Bill_POMasterReplica { get; set; }
        public virtual DbSet<BudgetHeader> BudgetHeaders { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<CapexApproverTable> CapexApproverTables { get; set; }
        public virtual DbSet<CapexCatagory> CapexCatagories { get; set; }
        public virtual DbSet<CapexFileUploadDetail> CapexFileUploadDetails { get; set; }
        public virtual DbSet<CapexInformationDetail> CapexInformationDetails { get; set; }
        public virtual DbSet<CapexInformationMaster> CapexInformationMasters { get; set; }
        public virtual DbSet<CategoryHR> CategoryHRs { get; set; }
        public virtual DbSet<CommentsTable> CommentsTables { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CourierBudgetEntry> CourierBudgetEntries { get; set; }
        public virtual DbSet<CourierBusinessUnit> CourierBusinessUnits { get; set; }
        public virtual DbSet<CourierComment> CourierComments { get; set; }
        public virtual DbSet<CourierCustomerTable> CourierCustomerTables { get; set; }
        public virtual DbSet<CourierRequestDetailsTable> CourierRequestDetailsTables { get; set; }
        public virtual DbSet<CourierType> CourierTypes { get; set; }
        public virtual DbSet<CourierUserWiseBusinessUnitPermission> CourierUserWiseBusinessUnitPermissions { get; set; }
        public virtual DbSet<CourierUserWiseCustomerPermission> CourierUserWiseCustomerPermissions { get; set; }
        public virtual DbSet<DesignationHR> DesignationHRs { get; set; }
        public virtual DbSet<DesignationTable> DesignationTables { get; set; }
        public virtual DbSet<DesignationTableOperation> DesignationTableOperations { get; set; }
        public virtual DbSet<ExceptionComment> ExceptionComments { get; set; }
        public virtual DbSet<ExceptionRequestDetail> ExceptionRequestDetails { get; set; }
        public virtual DbSet<ExceptionRequestHRComment> ExceptionRequestHRComments { get; set; }
        public virtual DbSet<ExceptionRequestHRDeatilsExtend> ExceptionRequestHRDeatilsExtends { get; set; }
        public virtual DbSet<ExceptionRequestHRDetail> ExceptionRequestHRDetails { get; set; }
        public virtual DbSet<ExceptionRequestHRMaster> ExceptionRequestHRMasters { get; set; }
        public virtual DbSet<IOUComment> IOUComments { get; set; }
        public virtual DbSet<LocationWisePurposeofVisit> LocationWisePurposeofVisits { get; set; }
        public virtual DbSet<LocationWiseStartPoint> LocationWiseStartPoints { get; set; }
        public virtual DbSet<LogTable> LogTables { get; set; }
        public virtual DbSet<ModuleTable> ModuleTables { get; set; }
        public virtual DbSet<MonthWiseSalaryInfo> MonthWiseSalaryInfoes { get; set; }
        public virtual DbSet<PositionCodeWiseManpower> PositionCodeWiseManpowers { get; set; }
        public virtual DbSet<PurposeofVisit> PurposeofVisits { get; set; }
        public virtual DbSet<SectionHR> SectionHRs { get; set; }
        public virtual DbSet<StaffCategoryTableOperation> StaffCategoryTableOperations { get; set; }
        public virtual DbSet<StartingPoint> StartingPoints { get; set; }
        public virtual DbSet<StartPointWiseBusinessUnit> StartPointWiseBusinessUnits { get; set; }
        public virtual DbSet<StartPointWiseRoute> StartPointWiseRoutes { get; set; }
        public virtual DbSet<SubSectionHR> SubSectionHRs { get; set; }
        public virtual DbSet<UnitHR> UnitHRs { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleBudgetEntry> VehicleBudgetEntries { get; set; }
        public virtual DbSet<VehicleComment> VehicleComments { get; set; }
        public virtual DbSet<VehicleDeligation> VehicleDeligations { get; set; }
        public virtual DbSet<VehicleRequestDetail> VehicleRequestDetails { get; set; }
        public virtual DbSet<VehicleRequestMaster> VehicleRequestMasters { get; set; }
        public virtual DbSet<VisitorComment> VisitorComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionApproverMaster>()
                .Property(e => e.BuyeId)
                .IsFixedLength();

            modelBuilder.Entity<VehicleApproverMaster>()
                .Property(e => e.COOId)
                .IsFixedLength();

            modelBuilder.Entity<VisitorDetailsTable>()
                .Property(e => e.CheckIn)
                .IsUnicode(false);

            modelBuilder.Entity<VisitorDetailsTable>()
                .Property(e => e.CheckOut)
                .IsUnicode(false);

            modelBuilder.Entity<CourierRequestDetailsTable>()
                .Property(e => e.AirwayBillno)
                .IsFixedLength();

            modelBuilder.Entity<CourierType>()
                .Property(e => e.Rate)
                .HasPrecision(18, 6);
        }
    }
}
