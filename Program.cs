namespace Example2
{
    using System.Collections;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
                {
                    Application.Run(new Form1());
                }
                catch (Exception e)
                {
                    writeError(e);
                }
        }


        private static void writeError(Exception e)
        {
          //  String path = Application.ExecutablePath 
            String path = Application.StartupPath + "\\Example.log";

            StreamWriter w = new StreamWriter(path, true);
            w.WriteLine("");
           String date = DateTime.Now.ToString();
            w.WriteLine(date + " ERROR message: " + e.Message);
                
            w.WriteLine(e.StackTrace);

            foreach (DictionaryEntry de in e.Data)
            {
                w.WriteLine("    Key: {0,-20}      Value: {1}", "'" + de.Key.ToString() + "'", de.Value);
            }
            w.Close();
        }
    }
}