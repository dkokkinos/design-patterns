using System;
using System.Collections.Generic;
using System.Linq;

namespace Template
{
    public class Program
    {
        public static void Main()
        {
            var customerReport = new CustomerReport("../../../customers.csv");
            var productReport = new ProductReport("../../../products.json", "../../../product_report.txt");

            var reportProcessor = new ReportProcessor(customerReport, productReport);
            reportProcessor.ProcessReports();
        }

        public class ReportProcessor
        {
            private readonly List<Report> _reports;

            public ReportProcessor(params Report[] reports)
            {
                _reports = reports.ToList();
            }

            public void ProcessReports()
            {
                _reports.ForEach(x => x.Run());
            }
        }

    }
}
