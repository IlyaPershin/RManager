using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RManager.Models.Repositoryes;

namespace RManager.Models
{
    public class DataManager
    {
        private ModelContainer cont;
        public BranchRepository branchRepository;
        public CategoryRepository categoryRepository;
        public CheckDishRepository checkDishRepository;
        public CheckMerchandiseRepository checkMerchandiseRepository;
        public ClientRepository clientRepository;
        public CompanyOwnerRepository companyOwnerRepository;
        public CompanyRepository companyRepository;
        public ContactPersonRepository contactPersonRepository;
        public DishRepository dishRepository;
        public DocumentRepository documentRepository;
        public EjectionRepository ejectionRepository;
        public EmployeeRepository employeeRepository;
        public EncashmentRepository encashmentRepository;
        public LandlordRepository landlordRepository;
        public OrderRepository orderRepository;
        public PersonRepository personRepository;
        public PositionRepository positionRepository;
        public PrepackRepository prepackRepository;
        public ProductRepository productRepository;
        public PurchaseRepository purchaseRepository;
        public RecipeDishIngrRepository recipeDishIngrRepository;
        public RecipeDishPrepRepository recipeDishPrepRepository;
        public RecipePrepIngrRepository recipePrepIngrRepository;
        public RecipePrepPrepRepository recipePrepPrepRepository;
        public RoomRepository roomRepository;
        public ShiftRepository shiftRepository;
        public TableRepository tableRepository;
        public WarehouseRepository warehouseRepository;

        public DataManager()
        {
            cont = new ModelContainer();
            branchRepository = new BranchRepository(cont);
            categoryRepository = new CategoryRepository(cont);
            checkDishRepository = new CheckDishRepository(cont);
            checkMerchandiseRepository = new CheckMerchandiseRepository(cont);
            clientRepository = new ClientRepository(cont);
            companyOwnerRepository = new CompanyOwnerRepository(cont);
            companyRepository = new CompanyRepository(cont);
            contactPersonRepository = new ContactPersonRepository(cont);
            dishRepository = new DishRepository(cont);
            documentRepository = new DocumentRepository(cont);
            ejectionRepository = new EjectionRepository(cont);
            employeeRepository = new EmployeeRepository(cont);
            encashmentRepository = new EncashmentRepository(cont);
            landlordRepository = new LandlordRepository(cont);
            orderRepository = new OrderRepository(cont);
            personRepository = new PersonRepository(cont);
            positionRepository = new PositionRepository(cont);
            prepackRepository = new PrepackRepository(cont);
            productRepository = new ProductRepository(cont);
            purchaseRepository = new PurchaseRepository(cont);
            recipeDishIngrRepository = new RecipeDishIngrRepository(cont);
            recipeDishPrepRepository = new RecipeDishPrepRepository(cont);
            recipePrepIngrRepository = new RecipePrepIngrRepository(cont);
            recipePrepPrepRepository = new RecipePrepPrepRepository(cont);
            roomRepository = new RoomRepository(cont);
            shiftRepository = new ShiftRepository(cont);
            tableRepository = new TableRepository(cont);
            warehouseRepository = new WarehouseRepository(cont);
        }
    }
}