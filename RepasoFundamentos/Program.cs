using System;

namespace RepasoFundamentos
{
    internal class Program
    {
        
        static string[] codigos = { "OC-101", "OC-102", "OC-103", "OC-104", "OC-105", "OC-106" };
        
        static string[] provedores = { "TechCorp", "LogiExpress", "InsumosGlobal", "TechCorp", "AlfaSuministros", "Serviredes" };
      
        static double[,] datos = { { 150, 10 }, { 450, 2 }, { 80, 50 }, { 120, 1 }, { 25, 100 }, { 600, 3 } };
        static double[] montos = new double[6];
        static double total = 0;
        static int cont = 0;

        static public bool Validaciones(double precio, double cant)
        {
            if (precio > 0 && cant > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error: el precio unitario y la cantidad deben ser > 0");
                return false;
            }
        }

        static public void Mont_Acum_Cont()
        {
          
            total = 0;
            cont = 0;

            for (int i = 0; i < codigos.Length; i++) 
            {
                if (Validaciones(datos[i, 0], datos[i, 1]))
                {
                    montos[i] = datos[i, 0] * datos[i, 1];
                    total = total + montos[i];
                    if (montos[i] > 1000)
                    {
                        cont++;
                    }
                }
            }

            Console.WriteLine("MÉTRICAS RESUMEN");
            Console.WriteLine("* GRAN TOTAL ACUMULADO: $ " + total);
            Console.WriteLine("* COMPRAS CRÍTICAS (> $1,000): " + cont + " órdenes");
        }

        static public void orden_desc()
        {
            int n = codigos.Length; 

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++) 
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double temp_Mon = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = temp_Mon;

                        string tmp_cod = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tmp_cod;

                        string tmp_prov = provedores[j];
                        provedores[j] = provedores[j + 1];
                        provedores[j + 1] = tmp_prov;

                        double tmp_precio = datos[j, 0];
                        datos[j, 0] = datos[j + 1, 0]; 
                        datos[j + 1, 0] = tmp_precio;

                        double tmp_cant = datos[j, 1];
                        datos[j, 1] = datos[j + 1, 1];
                        datos[j + 1, 1] = tmp_cant;
                    }
                }
            }
        }
        static public void buscar(string cod_buscar)
        {
            bool encontrado = false;
            if (string.IsNullOrWhiteSpace(cod_buscar))
            {
                Console.WriteLine("Valor vacío..!!");
                return;
            }
            for(int i= 0; i< codigos.Length; i++)
            {
                if (codigos[i]==cod_buscar)
                {
                    Console.WriteLine("Código encontrado: ");
                    Console.WriteLine("Proveedor: "+ provedores[i]);
                    Console.WriteLine("Monto: $" + montos[i]);
                    encontrado = true;
                    break;
                }
            }
            if(!encontrado)
                Console.WriteLine("Código no encontrado..!!");
        }
        static public void imprimir()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++");
            Console.WriteLine("CONTROL DE ÓRDENES DE COMPRA");
            Console.WriteLine("+++++++++++++++++++++++++++++");
            for(int i = 0; i <codigos.Length; i++)
            {
                Console.WriteLine("código: " + codigos[i]+ "|Prov: "+ provedores[i]);

            }
        }
        static void Main(string[] args)
        {
            Mont_Acum_Cont();
            orden_desc();
            imprimir();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("METRICAS RESUMEN: ");
            Console.WriteLine("* Gran Total Acumulado:          $" +total);
            Console.WriteLine("* Compras Críticas (> $1,000): "+cont+ "órdenes");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ingrese código a buscar: ");
            string cod = Console.ReadLine();
            buscar(cod);

        }
    }
}