using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient;

namespace Barbari_DAL
{
    public class SqlTableRefresh
    {
        public static SqlTableRefresh instance;
        public static SqlTableRefresh Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlTableRefresh();
                }
                return instance;
            }
        }
        public event EventHandler<Users_Tbl> usersRefresh;
        public event EventHandler<Customers_Tbl> customersRefresh;
        public event EventHandler<Ranande_Tbl> ranandeRefresh;
        public event EventHandler<BarErsali_Tbl> barErsaliRefresh;
        public event EventHandler<KalaDaryafti_Tbl> kalaDaryaftiRefresh;
        public event EventHandler<City_Tbl> cityRefresh;
        SqlTableDependency<Users_Tbl> usersDependency;
        SqlTableDependency<Customers_Tbl> customersDependency;
        SqlTableDependency<Ranande_Tbl> ranandeDependency;
        SqlTableDependency<BarErsali_Tbl> barErsaliDependency;
        SqlTableDependency<KalaDaryafti_Tbl> kalaDaryaftiDependency;
        SqlTableDependency<City_Tbl> cityDependency;
        
        private SqlTableRefresh()
        {
            var notify = DmlTriggerType.Insert | DmlTriggerType.Update;
            // اکانت ها
            usersDependency = new SqlTableDependency<Users_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: notify);
            usersDependency.OnChanged += UsersDependency_OnChanged; ;
            StartUsers();
            // مشتری ها
            customersDependency = new SqlTableDependency<Customers_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: notify);
            customersDependency.OnChanged += CustomersDependency_OnChanged; ;
            StartCustomers();
            // راننده
            ranandeDependency = new SqlTableDependency<Ranande_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: notify);
            ranandeDependency.OnChanged += RanandeDependency_OnChanged; ;
            StartRanande();
            // بار ارسالی
            barErsaliDependency = new SqlTableDependency<BarErsali_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: DmlTriggerType.All);
            barErsaliDependency.OnChanged += BarErsaliDependency_OnChanged; ;
            StartBarErsali();
            // کالا دریافتی
            kalaDaryaftiDependency = new SqlTableDependency<KalaDaryafti_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: DmlTriggerType.All);
            kalaDaryaftiDependency.OnChanged += KalaDaryaftiDependency_OnChanged; ;
            StartkalaDaryafti();
            // شهر ها
            cityDependency = new SqlTableDependency<City_Tbl>(Properties.Settings.Default.Barbari_DbConnectionString, notifyOn: DmlTriggerType.All);
            cityDependency.OnChanged += CityDependency_OnChanged; ;
            StartCity();
        }

        private void CityDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<City_Tbl> e)
        {
            if (cityRefresh != null)
            {
                cityRefresh(sender, e.Entity);
            }
        }

        private void KalaDaryaftiDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<KalaDaryafti_Tbl> e)
        {
            if (kalaDaryaftiRefresh != null)
            {
                kalaDaryaftiRefresh(sender, e.Entity);
            }
        }

        private void BarErsaliDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<BarErsali_Tbl> e)
        {
            if (barErsaliRefresh != null)
            {
                barErsaliRefresh(sender, e.Entity);
            }
        }

        private void RanandeDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Ranande_Tbl> e)
        {
            if (ranandeRefresh != null)
            {
                ranandeRefresh(sender, e.Entity);
            }
        }

        private void CustomersDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Customers_Tbl> e)
        {
            if (customersRefresh != null)
            {
                customersRefresh(sender, e.Entity);
            }
        }

        private void UsersDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Users_Tbl> e)
        {
            if (usersRefresh != null)
            {
                usersRefresh(sender, e.Entity);
            }
        }

        private bool StartUsers()
        {
            try
            {
                usersDependency.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool StartCustomers()
        {
            try
            {
                customersDependency.Start();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private bool StartRanande()
        {
            try
            {
                ranandeDependency.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool StartBarErsali()
        {
            try
            {
                barErsaliDependency.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool StartkalaDaryafti()
        {
            try
            {
                kalaDaryaftiDependency.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool StartCity()
        {
            try
            {
                cityDependency.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Dispose()
        {
            usersDependency.Stop();
            usersDependency.Dispose();
            customersDependency.Stop();
            customersDependency.Dispose();
            ranandeDependency.Stop();
            ranandeDependency.Dispose();
            barErsaliDependency.Stop();
            barErsaliDependency.Dispose();
            kalaDaryaftiDependency.Stop();
            kalaDaryaftiDependency.Dispose();
            cityDependency.Stop();
            cityDependency.Dispose();
        }
        ~SqlTableRefresh()
        {
            Dispose();
        }
    }
}

