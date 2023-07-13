//using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Exportables_Sisde
{
   public class ClassFunciones
    {

        
        
        //Consulta el subtipo al que pertenece la estructura
        /*
        public Double ConsultaSubtipo(string IN_CODIGOESTRUCTURA)
        {l
            OracleConnection conn = ConnOra.GetDBConnection();
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            string strQuery = string.Empty;
            double varSubtipo = -1;
            try
            {
                strQuery = "select F_SUBTIPO('" + IN_CODIGOESTRUCTURA + "') AS SUBTIPO from dual";
                objCmd.CommandText = strQuery;
                objCmd.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
                objReader = objCmd.ExecuteReader();
                //if (objReader.HasRows)
                //{
                    while (objReader.Read())
                    {
                        if (objReader["SUBTIPO"] != DBNull.Value)
                        {
                            varSubtipo = Convert.ToDouble(objReader["SUBTIPO"].ToString());
                        }
                        else
                        {
                            varSubtipo = -1;
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR," + ex.Message);
                return -1;
            }

            conn.Close();
            return varSubtipo;
        }
        */
        
        //lista estructuras desmanteladas

        public List<string> ListDesmantelada(string IN_COD_DIS)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTR_FLASH_DESM_SELECT";
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_ESTR_FLASH_DESM"].ToString() + "¬" +
                               objReader["COD_DIS"].ToString() + "¬" +
                               objReader["CODI_ESTR"].ToString() + "¬" +
                               objReader["CODI_DESCRIPCION"].ToString() + "¬" +
                               objReader["CANTIDAD"].ToString() + "¬" +
                               objReader["FECHA_FORMADA"].ToString() + "¬" +
                               objReader["CLASIFICACION"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //estructuras desmanteladas
        public List<string> InsertEstructurasFlashDesm(string IN_COD_DIS, string IN_CODI_ESTR, string IN_CODI_CLAS, string IN_CANTIDAD)
        {

            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTR_FLASH_DESM_INSERT";
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_CODI_ESTR", OracleType.VarChar).Value = IN_CODI_ESTR;
                objCmd.Parameters.Add("IN_CODI_CLAS", OracleType.VarChar).Value = IN_CODI_CLAS;
                objCmd.Parameters.Add("IN_CANTIDAD", OracleType.VarChar).Value = IN_CANTIDAD;


                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {


                    vardatos = objReader["ID_ESTR_FLASH_DESM"].ToString() + "¬" +
                               objReader["COD_DIS"].ToString() + "¬" +
                               objReader["CODI_ESTR"].ToString() + "¬" +
                               objReader["CODI_DESCRIPCION"].ToString() + "¬" +
                               objReader["CANTIDAD"].ToString() + "¬" +
                               objReader["FECHA_FORMADA"].ToString() + "¬" +
                               objReader["CLASIFICACION"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //lista estructuras flash
        public List<string> ListProyectada(string IN_COD_DIS)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTR_FLASH_SELECT";
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_ESTR_FLASH"].ToString() + "¬" +
                               objReader["COD_DIS"].ToString() + "¬" +
                               objReader["CODI_ESTR"].ToString() + "¬" +
                               objReader["CODI_DESCRIPCION"].ToString() + "¬" +
                               objReader["CANTIDAD"].ToString() + "¬" +
                               objReader["FECHA_FORMADA"].ToString() + "¬" +
                               objReader["CLASIFICACION"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //Insert estructuras flash



        public List<string> InsertEstructurasFlash(string IN_COD_DIS, string IN_CODI_ESTR, string IN_CODI_CLAS, string IN_CANTIDAD)
        {

            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTR_FLASH_INSERT";
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_CODI_ESTR", OracleType.VarChar).Value = IN_CODI_ESTR;
                objCmd.Parameters.Add("IN_CODI_CLAS", OracleType.VarChar).Value = IN_CODI_CLAS;
                objCmd.Parameters.Add("IN_CANTIDAD", OracleType.VarChar).Value = IN_CANTIDAD;

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {


                    vardatos = objReader["ID_ESTR_FLASH"].ToString() + "¬" +
                               objReader["COD_DIS"].ToString() + "¬" +
                               objReader["CODI_ESTR"].ToString() + "¬" +
                               objReader["CODI_DESCRIPCION"].ToString() + "¬" +
                               objReader["CANTIDAD"].ToString() + "¬" +
                               objReader["FECHA_FORMADA"].ToString() + "¬" +
                               objReader["CLASIFICACION"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //consulta de lista de estructuras

        public List<string> ListaEstructuras(string IN_CODI_CLAS)
        {

            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTRUCTURAS_LISTA";
                objCmd.Parameters.Add("IN_CODI_CLAS", OracleType.VarChar).Value = IN_CODI_CLAS;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["CODIGOESTRUCTURA"].ToString() + "¬" +
                               objReader["COD_UNIDAD"].ToString() + "¬" +
                               objReader["CODI_CLAS"].ToString() + "¬" +
                               objReader["ID_CLAS_MO"].ToString() + "¬" +
                               objReader["DESCRIPCIONCORTA"].ToString() + "¬" +
                               objReader["DESCRIPCIONLARGA"].ToString() + "¬" +
                               objReader["POTENCIA"].ToString() + "¬" +
                               objReader["TIPO_MAT"].ToString() + "¬" +
                               objReader["PRIORIDAD_ESTR"].ToString() + "¬" +
                                objReader["TIPO_ESTR"].ToString() + "¬" +
                               objReader["NIVEL_VOLTAJE_ESTR"].ToString() + "¬" +
                               objReader["PRECIO_ESTR"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }
        //fin de lista de estructuras

        //consulta lista de clases

        public List<string> ConsultaClases()
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_CLAS_ESTR_LISTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["CODI_CLAS"].ToString() + "¬" +
                               objReader["DESC_CLAS"].ToString() + "¬" +
                               objReader["SUB_CLAS"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //fin de lista de clases
        public List<string> ImportUpdatePuntoCarga(
string IN_ID_PUNTO_CARGA,
string IN_CODIGOCLIENTE,
string IN_MEDIDOR,
string IN_NOMBRE_CLIENTE,
string IN_APELLIDO_CLIENTE)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_UPDATE_PUNTOCARGA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_PUNTO_CARGA", OracleType.VarChar).Value = IN_ID_PUNTO_CARGA;
                objCmd.Parameters.Add("IN_CODIGOCLIENTE", OracleType.VarChar).Value = IN_CODIGOCLIENTE;
                objCmd.Parameters.Add("IN_MEDIDOR", OracleType.VarChar).Value = IN_MEDIDOR;
                objCmd.Parameters.Add("IN_NOMBRE_CLIENTE", OracleType.VarChar).Value = IN_NOMBRE_CLIENTE;
                objCmd.Parameters.Add("IN_APELLIDO_CLIENTE", OracleType.VarChar).Value = IN_APELLIDO_CLIENTE;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        public List<string> ImportInsertPuntoCarga(
string IN_ID_POSTE,
string IN_ANT,
string IN_ACTUAL,
string IN_FASECONEXION,
string IN_CODIGOCLIENTE,
string IN_MEDIDOR,
string IN_COOR_X,
string IN_COOR_Y,
string IN_NOMBRE_CLIENTE,
string IN_APELLIDO_CLIENTE,
string IN_COD_DIS,
string IN_TIPO_RED)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_PUNTOCARGA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_ANT", OracleType.VarChar).Value = IN_ANT;
                objCmd.Parameters.Add("IN_ACTUAL", OracleType.VarChar).Value = IN_ACTUAL;
                objCmd.Parameters.Add("IN_FASECONEXION", OracleType.VarChar).Value = IN_FASECONEXION;
                objCmd.Parameters.Add("IN_CODIGOCLIENTE", OracleType.VarChar).Value = IN_CODIGOCLIENTE;
                objCmd.Parameters.Add("IN_MEDIDOR", OracleType.VarChar).Value = IN_MEDIDOR;
                objCmd.Parameters.Add("IN_COOR_X", OracleType.VarChar).Value = IN_COOR_X;
                objCmd.Parameters.Add("IN_COOR_Y", OracleType.VarChar).Value = IN_COOR_Y;
                objCmd.Parameters.Add("IN_NOMBRE_CLIENTE", OracleType.VarChar).Value = IN_NOMBRE_CLIENTE;
                objCmd.Parameters.Add("IN_APELLIDO_CLIENTE", OracleType.VarChar).Value = IN_APELLIDO_CLIENTE;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;

                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["MENSAJE"].ToString() + "¬";
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        //ingreso de pararrayos

        public List<string> ImportInsertPararrayos(
string IN_CODIGOELEMENTO_POSTE,
string IN_TIPO_RED,
string IN_SUBTIPO,
string IN_CODIGOESTRUCTURA)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_PARARRAYOS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }
        //ingreso de transformadores

        public List<string> ImportInsertTrafos(
string IN_CODIGOELEMENTO_POSTE,
string IN_COD_DIS,
string IN_SUBTIPO,
string IN_CODIGOESTRUCTURA,
string IN_CODIGOPUESTO,
string IN_TIPO_RED)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_TRAFOS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }




        //ingreso de seccionadores fusible

        public List<string> ImportInsertSeccionadoresFusible(
string IN_CODIGOELEMENTO_POSTE,
   string IN_SUBTIPO,
string IN_CODIGOESTRUCTURA,
string IN_CODIGOPUESTO,
string IN_TIPO_RED)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_PUESTOSECCIONADORFUSIBLE";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //ingreso de seccionadores cuchilla
        public List<string> ImportInsertSeccionadores(
    string IN_CODIGOELEMENTO_POSTE,
        string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_CODIGOPUESTO,
 string IN_TIPO_RED)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_PUESTOSECCIONADOR";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }
        //ingreso de tensores


        public List<string> ImportInsertTensores(string IN_CODIGOELEMENTO_POSTE,
     string       IN_TIPO_RED,
 string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_ROTACIONSIMBOLO)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_TENSOR";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_ROTACIONSIMBOLO", OracleType.VarChar).Value = IN_ROTACIONSIMBOLO;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        //fin de ingreso de tensores



        public List<string> ImportInsertLuminarias(string IN_COD_DIS,
  string IN_CODIGOELEMENTO_POSTE,
 string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_TIPO_RED)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_LUMINARIA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO_POSTE", OracleType.VarChar).Value = IN_CODIGOELEMENTO_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //Import insert estructuras
        public List<string> ImportInsertEstructuras(
string IN_CODIGOELEMENTO,
string IN_TIPORED,
string IN_CODIGOESTRUCTURA,
string IN_CANTIDAD)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_ESTRUCTURAENPOSTE";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO", OracleType.VarChar).Value = IN_CODIGOELEMENTO;
                objCmd.Parameters.Add("IN_TIPORED", OracleType.VarChar).Value = IN_TIPORED;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CANTIDAD", OracleType.VarChar).Value = IN_CANTIDAD;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //procedimientos de importacion

        public List<string> ImportUpdatePostes(
string IN_CODIGOELEMENTO,
string IN_TIPORED,
string IN_SUBTIPO,
string IN_CODIGOESTRUCTURA,
string IN_TIPOCIMIENTO,
string IN_ATERRAMIENTO
)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_UPDATE_SD_ESTRUCTURASOPORTE";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_IDDISENO", OracleType.VarChar).Value = ClassGlobalVar.GlobalIdDisenio;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO", OracleType.VarChar).Value = IN_CODIGOELEMENTO;
                objCmd.Parameters.Add("IN_TIPORED", OracleType.VarChar).Value = IN_TIPORED;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_TIPOCIMIENTO", OracleType.VarChar).Value = IN_TIPOCIMIENTO;
                objCmd.Parameters.Add("IN_ATERRAMIENTO", OracleType.VarChar).Value = IN_ATERRAMIENTO;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }






        public List<string> ImportInsertPostes(
string IN_COD_DIS,
string IN_SUBTIPO,
string IN_CODIGOESTRUCTURA,
string IN_CODIGOELEMENTO,
string IN_TIPOCIMIENTO,
string IN_ATERRAMIENTO,
string IN_ESTADO,
string IN_PROPIEDAD,
string IN_TIPOUSOPOSTE,
string IN_REUBICADO,
string IN_USO_GRUA,
string IN_TIPO_RED,
string IN_COORD_X,
string IN_COORD_Y,
string IN_OBSERVACIONES)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_IMPORT_INSERT_SD_ESTRUCTURASOPORTE";
                objCmd.CommandType = CommandType.StoredProcedure;


                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO", OracleType.VarChar).Value = IN_CODIGOELEMENTO;
                objCmd.Parameters.Add("IN_TIPOCIMIENTO", OracleType.VarChar).Value = IN_TIPOCIMIENTO;
                objCmd.Parameters.Add("IN_ATERRAMIENTO", OracleType.VarChar).Value = IN_ATERRAMIENTO;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_PROPIEDAD", OracleType.VarChar).Value = IN_PROPIEDAD;
                objCmd.Parameters.Add("IN_TIPOUSOPOSTE", OracleType.VarChar).Value = IN_TIPOUSOPOSTE;
                objCmd.Parameters.Add("IN_REUBICADO", OracleType.VarChar).Value = IN_REUBICADO;
                objCmd.Parameters.Add("IN_USO_GRUA", OracleType.VarChar).Value = IN_USO_GRUA;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_COORD_X", OracleType.VarChar).Value = IN_COORD_X;
                objCmd.Parameters.Add("IN_COORD_Y", OracleType.VarChar).Value = IN_COORD_Y;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();


            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("ERROR," + ex.Message);
                //varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        //fin de procedimientos de importacion


        //select tramo baja tension
        public List<string> SelectBajaTension(string IN_ID_TRAMOBAJAAEREO)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SELECT_SD_TRAMOBAJATENSIONAEREO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_TRAMOBAJAAEREO", OracleType.VarChar).Value = IN_ID_TRAMOBAJAAEREO;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_TRAMOBAJAAEREO"].ToString() + "¬" +
                                objReader["COD_DIS"].ToString() + "¬" +
                                objReader["SUBTIPO"].ToString() + "¬" +
                                objReader["FASECONEXION"].ToString() + "¬" +
                                objReader["VOLTAJE"].ToString() + "¬" +
                                objReader["CODIGOCONDUCTORFASE"].ToString() + "¬" +
                                objReader["CODIGOCONDUCTORNEUTRO"].ToString() + "¬" +
                                objReader["CONFIGURACIONCONDUCTORES"].ToString() + "¬" +
                                objReader["SECUENCIAFASE"].ToString() + "¬" +
                                objReader["ESTADO"].ToString() + "¬" +
                                objReader["TIPOUSOTRAMO"].ToString() + "¬" +
                                objReader["TIPO_RED"].ToString() + "¬" +
                                objReader["COOR_X1"].ToString() + "¬" +
                                objReader["COOR_Y1"].ToString() + "¬" +
                                objReader["COOR_X2"].ToString() + "¬" +
                                objReader["COOR_Y2"].ToString() + "¬" +
                                objReader["OBSERVACIONES"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }
            conn.Close();
            return varListRegistros;
        }
        //select tramo media tension

        public List<string> SelectMediaTension(string IN_ID_TRAMODISTAEREO)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SELECT_SD_TRAMODISTRIBUCIONAEREO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_TRAMODISTAEREO", OracleType.VarChar).Value = IN_ID_TRAMODISTAEREO;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_TRAMODISTAEREO"].ToString() + "¬" +
                                objReader["COD_DIS"].ToString() + "¬" +
                                objReader["SUBTIPO"].ToString() + "¬" +
                                objReader["FASECONEXION"].ToString() + "¬" +
                                objReader["VOLTAJE"].ToString() + "¬" +
                                objReader["CODIGOCONDUCTORFASE"].ToString() + "¬" +
                                objReader["CODIGOCONDUCTORNEUTRO"].ToString() + "¬" +
                                objReader["CONFIGURACIONCONDUCTORES"].ToString() + "¬" +
                                objReader["SECUENCIAFASE"].ToString() + "¬" +
                                objReader["ESTADO"].ToString() + "¬" +
                                objReader["TIPO_RED"].ToString() + "¬" +
                                objReader["COOR_X1"].ToString() + "¬" +
                                objReader["COOR_Y1"].ToString() + "¬" +
                                objReader["COOR_X2"].ToString() + "¬" +
                                objReader["COOR_Y2"].ToString() + "¬" +
                                objReader["OBSERVACIONES"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }
            conn.Close();
            return varListRegistros;
        }



        //Insert pararrayo

        public List<string> InsertPararrayo(
 string IN_ID_POSTE,
 string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_ESTADO,
 string IN_OBSERVACIONES)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            List<string> varListRegistros = new List<string>();
            /*
            string varSubtipopararrayo = string.Empty;
            //subtipo pararrayo
            if (IN_CODIGOESTRUCTURA.Trim().ToString().Substring(0, 2) == "PT")
            {
                varSubtipopararrayo = "1";

            }

            if (IN_CODIGOESTRUCTURA.Trim().ToString().Substring(1, 1) == "P")
            {
                varSubtipopararrayo = "2";
            }
            */

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_PARARRAYOS";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_PARARAYOS"].ToString() + "," +
                                objReader["ID_POSTE"].ToString() + "," +
                                objReader["SUBTIPO"].ToString() + "," +
                                objReader["CODIGOESTRUCTURA"].ToString() + "," +
                                objReader["ESTADO"].ToString() + "," +
                                objReader["OBSERVACIONES"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //Insert seccionador fusible

        public List<string> InsertSecFusible(string IN_ID_POSTE,
 string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_CODIGOPUESTO,
 string IN_FASECONEXION,
 string IN_VOLTAJE,
 string IN_POSICIONNORMAL_A,
 string IN_POSICIONNORMAL_B,
 string IN_POSICIONNORMAL_C,
 string IN_POSICIONACTUAL_A,
 string IN_POSICIONACTUAL_B,
 string IN_POSICIONACTUAL_C,
 string IN_CORRIENTE,
 string IN_TIRAFUSIBLE,
 string IN_TIPO,
 string IN_CORRIENTEMAXCORTOCIRCUITO,
 string IN_TIPO_RED,
 string IN_REUBICADO,
 string IN_COOR_X,
 string IN_COOR_Y,
 string IN_OBSERVACIONES,
 string IN_ESTADO,
 string IN_COD_DIS)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            List<string> varListRegistros = new List<string>();

            /*
            string varSubtiposeccionadorFusible = string.Empty;
            switch (IN_CODIGOESTRUCTURA.ToString().Substring(1, 1))
            {
                case "S":
                    varSubtiposeccionadorFusible = "1";
                    break;
                case "D":
                    varSubtiposeccionadorFusible = "2";
                    break;
                case "E":
                    varSubtiposeccionadorFusible = "3";
                    break;
                default:
                    varSubtiposeccionadorFusible = "0";
                    break;
            }
            */
            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_PUESTOSECCIONADORFUSIBLE";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_FASECONEXION", OracleType.VarChar).Value = IN_FASECONEXION;
                objCmd.Parameters.Add("IN_VOLTAJE", OracleType.VarChar).Value = IN_VOLTAJE;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_A", OracleType.VarChar).Value = IN_POSICIONNORMAL_A;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_B", OracleType.VarChar).Value = IN_POSICIONNORMAL_B;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_C", OracleType.VarChar).Value = IN_POSICIONNORMAL_C;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_A", OracleType.VarChar).Value = IN_POSICIONACTUAL_A;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_B", OracleType.VarChar).Value = IN_POSICIONACTUAL_B;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_C", OracleType.VarChar).Value = IN_POSICIONACTUAL_C;
                objCmd.Parameters.Add("IN_CORRIENTE", OracleType.VarChar).Value = IN_CORRIENTE;
                objCmd.Parameters.Add("IN_TIRAFUSIBLE", OracleType.VarChar).Value = IN_TIRAFUSIBLE;
                objCmd.Parameters.Add("IN_TIPO", OracleType.VarChar).Value = IN_TIPO;
                objCmd.Parameters.Add("IN_CORRIENTEMAXCORTOCIRCUITO", OracleType.VarChar).Value = IN_CORRIENTEMAXCORTOCIRCUITO;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_REUBICADO", OracleType.VarChar).Value = IN_REUBICADO;
                objCmd.Parameters.Add("IN_COOR_X", OracleType.VarChar).Value = IN_COOR_X;
                objCmd.Parameters.Add("IN_COOR_Y", OracleType.VarChar).Value = IN_COOR_Y;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["ID_PUEST_SEC_FUS"].ToString() + '^' +
                                objReader["ID_POSTE"].ToString() + '^' +
                                objReader["SUBTIPO"].ToString() + '^' +
                                objReader["CODIGOESTRUCTURA"].ToString() + '^' +
                                objReader["CODIGOPUESTO"].ToString() + '^' +
                                objReader["FASECONEXION"].ToString() + '^' +
                                objReader["VOLTAJE"].ToString() + '^' +
                                objReader["POSICIONNORMAL_A"].ToString() + '^' +
                                objReader["POSICIONNORMAL_B"].ToString() + '^' +
                                objReader["POSICIONNORMAL_C"].ToString() + '^' +
                                objReader["POSICIONACTUAL_A"].ToString() + '^' +
                                objReader["POSICIONACTUAL_B"].ToString() + '^' +
                                objReader["POSICIONACTUAL_C"].ToString() + '^' +
                                objReader["CORRIENTE"].ToString() + '^' +
                                objReader["TIRAFUSIBLE"].ToString() + '^' +
                                objReader["TIPO"].ToString() + '^' +
                                objReader["CORRIENTEMAXCORTOCIRCUITO"].ToString() + '^' +
                                objReader["TIPO_RED"].ToString() + '^' +
                                objReader["REUBICADO"].ToString() + '^' +
                                objReader["COOR_X"].ToString() + '^' +
                                objReader["COOR_Y"].ToString() + '^' +
                                objReader["OBSERVACIONES"].ToString() + '^' +
                                objReader["ESTADO"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //Insert seccionador cuchilla

        public List<string> InsertSecCuchilla(string IN_ID_POSTE,
  string IN_SUBTIPO,
  string IN_CODIGOESTRUCTURA,
  string IN_CODIGOPUESTO,
  string IN_FASECONEXION,
  string IN_VOLTAJE,
  string IN_POSICIONNORMAL_A,
  string IN_POSICIONNORMAL_B,
  string IN_POSICIONNORMAL_C,
  string IN_POSICIONACTUAL_A,
  string IN_POSICIONACTUAL_B,
  string IN_POSICIONACTUAL_C,
  string IN_CORRIENTE,
  string IN_CORRIENTE_3F_CIRCUITO,
  string IN_CORRIENTE_1F_CIRCUITO,
  string IN_CORRIENTEMAXCORTOCIRCUITO,
  string IN_TIPO_RED,
  string IN_REUBICADO,
  string IN_COOR_X,
  string IN_COOR_Y,
  string IN_OBSERVACIONES,
  string IN_ESTADO,
  string IN_COD_DIS)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
                        List<string> varListRegistros = new List<string>();
            /*
            string varSubtiposeccionador = string.Empty;
            string varauxcod = IN_CODIGOESTRUCTURA.ToString().Substring(1, 1);
            switch (varauxcod)
            {
                case "C":
                    varSubtiposeccionador = "1";
                    break;
                case "O":
                    varSubtiposeccionador = "2";
                    break;
                case "A":
                    varSubtiposeccionador = "3";
                    break;
                case "N":
                    varSubtiposeccionador = "4";
                    break;
                default:
                    varSubtiposeccionador = "0";
                    break;
            }
            */
            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_PUESTOSECCIONADOR";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_FASECONEXION", OracleType.VarChar).Value = IN_FASECONEXION;
                objCmd.Parameters.Add("IN_VOLTAJE", OracleType.VarChar).Value = IN_VOLTAJE;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_A", OracleType.VarChar).Value = IN_POSICIONNORMAL_A;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_B", OracleType.VarChar).Value = IN_POSICIONNORMAL_B;
                objCmd.Parameters.Add("IN_POSICIONNORMAL_C", OracleType.VarChar).Value = IN_POSICIONNORMAL_C;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_A", OracleType.VarChar).Value = IN_POSICIONACTUAL_A;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_B", OracleType.VarChar).Value = IN_POSICIONACTUAL_B;
                objCmd.Parameters.Add("IN_POSICIONACTUAL_C", OracleType.VarChar).Value = IN_POSICIONACTUAL_C;
                objCmd.Parameters.Add("IN_CORRIENTE", OracleType.VarChar).Value = IN_CORRIENTE;
                objCmd.Parameters.Add("IN_CORRIENTE_3F_CIRCUITO", OracleType.VarChar).Value = IN_CORRIENTE_3F_CIRCUITO;
                objCmd.Parameters.Add("IN_CORRIENTE_1F_CIRCUITO", OracleType.VarChar).Value = IN_CORRIENTE_1F_CIRCUITO;
                objCmd.Parameters.Add("IN_CORRIENTEMAXCORTOCIRCUITO", OracleType.VarChar).Value = IN_CORRIENTEMAXCORTOCIRCUITO;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_REUBICADO", OracleType.VarChar).Value = IN_REUBICADO;
                objCmd.Parameters.Add("IN_COOR_X", OracleType.VarChar).Value = IN_COOR_X;
                objCmd.Parameters.Add("IN_COOR_Y", OracleType.VarChar).Value = IN_COOR_Y;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["ID_PUEST_SEC_CUCHI"].ToString() + "^" +
                                objReader["ID_POSTE"].ToString() + "^" +
                                objReader["SUBTIPO"].ToString() + "^" +
                                objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                                objReader["CODIGOPUESTO"].ToString() + "^" +
                                objReader["FASECONEXION"].ToString() + "^" +
                                objReader["VOLTAJE"].ToString() + "^" +
                                objReader["POSICIONNORMAL_A"].ToString() + "^" +
                                objReader["POSICIONNORMAL_B"].ToString() + "^" +
                                objReader["POSICIONNORMAL_C"].ToString() + "^" +
                                objReader["POSICIONACTUAL_A"].ToString() + "^" +
                                objReader["POSICIONACTUAL_B"].ToString() + "^" +
                                objReader["POSICIONACTUAL_C"].ToString() + "^" +
                                objReader["CORRIENTE"].ToString() + "^" +
                                objReader["CORRIENTE_3F_CIRCUITO"].ToString() + "^" +
                                objReader["CORRIENTE_1F_CIRCUITO"].ToString() + "^" +
                                objReader["CORRIENTEMAXCORTOCIRCUITO"].ToString() + "^" +
                                objReader["TIPO_RED"].ToString() + "^" +
                                objReader["REUBICADO"].ToString() + "^" +
                                objReader["COOR_X"].ToString() + "^" +
                                objReader["COOR_Y"].ToString() + "^" +
                                objReader["OBSERVACIONES"].ToString() + "^" +
                                objReader["ESTADO"].ToString();

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //Insert transformadores

        public List<string> InsertTrafo(string IN_GID_POSTE,
   string IN_COD_DIS,
  string IN_SUBTIPO,
  string IN_CODIGOESTRUCTURA,
 string IN_CODIGOPUESTO,
  string IN_FASECONEXION,
  string IN_VOLTAJE,
  string IN_POTENCIAKVA,
  string IN_CONFIGURACIONLADOBAJA,
  string IN_TRAFO,
  string IN_PROPIEDAD,
  string IN_ESTADO,
  string IN_VOLTAJESECUNDARIO,
  string IN_CONFIGURACIONLADOMEDIA,
  string IN_TIPO_TRAFO,
  string IN_TIPO_USO_RED,
  string IN_TIPO_RED,
  string IN_REUBICADO,
  string IN_COOR_X,
  string IN_COOR_Y,
  string IN_OBSERVACIONES)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            List<string> varListRegistros = new List<string>();

            /*
            string varSubtipoTrafo = string.Empty;
            string varauxsubt = IN_CODIGOESTRUCTURA.Trim().ToString().Substring(0, 2);
            switch (varauxsubt)
            {
                case "1C":
                    varSubtipoTrafo = "1";
                    break;
                case "1A":
                    varSubtipoTrafo = "1";
                    break;
                case "1O":
                    varSubtipoTrafo = "2";
                    break;
                case "1P":
                    varSubtipoTrafo = "3";
                    break;
                case "3C":
                    varSubtipoTrafo = "5";
                    break;
                case "3A":
                    varSubtipoTrafo = "5";
                    break;
                case "3O":
                    varSubtipoTrafo = "6";
                    break;
                case "3P":
                    varSubtipoTrafo = "7";
                    break;
                case "3B":
                    varSubtipoTrafo = "9";
                    break;
                case "3V":
                    varSubtipoTrafo = "10";
                    break;
                case "3N":
                    varSubtipoTrafo = "11";
                    break;
                case "3F":
                    varSubtipoTrafo = "12";
                    break;
                case "2C":
                    varSubtipoTrafo = "13";
                    break;

                default:
                    varSubtipoTrafo = "0";
                    break;
            }
            */
            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_PUESTOTRANSFDISTRIBUCION";
                objCmd.CommandType = CommandType.StoredProcedure;


                objCmd.Parameters.Add("IN_GID_POSTE", OracleType.VarChar).Value = IN_GID_POSTE;
                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOPUESTO", OracleType.VarChar).Value = IN_CODIGOPUESTO;
                objCmd.Parameters.Add("IN_FASECONEXION", OracleType.VarChar).Value = IN_FASECONEXION;
                objCmd.Parameters.Add("IN_VOLTAJE", OracleType.VarChar).Value = IN_VOLTAJE;
                objCmd.Parameters.Add("IN_POTENCIAKVA", OracleType.VarChar).Value = IN_POTENCIAKVA;
                objCmd.Parameters.Add("IN_CONFIGURACIONLADOBAJA", OracleType.VarChar).Value = IN_CONFIGURACIONLADOBAJA;
                objCmd.Parameters.Add("IN_TRAFO", OracleType.VarChar).Value = IN_TRAFO;
                objCmd.Parameters.Add("IN_PROPIEDAD", OracleType.VarChar).Value = IN_PROPIEDAD;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_VOLTAJESECUNDARIO", OracleType.VarChar).Value = IN_VOLTAJESECUNDARIO;
                objCmd.Parameters.Add("IN_CONFIGURACIONLADOMEDIA", OracleType.VarChar).Value = IN_CONFIGURACIONLADOMEDIA;
                objCmd.Parameters.Add("IN_TIPO_TRAFO", OracleType.VarChar).Value = IN_TIPO_TRAFO;
                objCmd.Parameters.Add("IN_TIPO_USO_RED", OracleType.VarChar).Value = IN_TIPO_USO_RED;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_REUBICADO", OracleType.VarChar).Value = IN_REUBICADO;
                objCmd.Parameters.Add("VAR_COOR_X", OracleType.VarChar).Value = IN_COOR_X;
                objCmd.Parameters.Add("VAR_COOR_Y", OracleType.VarChar).Value = IN_COOR_Y;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["ID_PUEST_TRANSF"].ToString() + "^" +
                                objReader["GID_POSTE"].ToString() + "^" +
                                objReader["COD_DIS"].ToString() + "^" +
                                objReader["SUBTIPO"].ToString() + "^" +
                                objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                                objReader["CODIGOPUESTO"].ToString() + "^" +
                                objReader["FASECONEXION"].ToString() + "^" +
                                objReader["VOLTAJE"].ToString() + "^" +
                                objReader["POTENCIAKVA"].ToString() + "^" +
                                objReader["CONFIGURACIONLADOBAJA"].ToString() + "^" +
                                objReader["TRAFO"].ToString() + "^" +
                                objReader["PROPIEDAD"].ToString() + "^" +
                                objReader["ESTADO"].ToString() + "^" +
                                objReader["VOLTAJESECUNDARIO"].ToString() + "^" +
                                objReader["CONFIGURACIONLADOMEDIA"].ToString() + "^" +
                                objReader["TIPO_TRAFO"].ToString() + "^" +
                                objReader["TIPO_USO_RED"].ToString() + "^" +
                                objReader["TIPO_RED"].ToString() + "^" +
                                objReader["REUBICADO"].ToString() + "^" +
                                objReader["COOR_X"].ToString() + "^" +
                                objReader["COOR_Y"].ToString() + "^" +
                                objReader["OBSERVACIONES"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        //Insert luminarias

        public List<string> InsertLuminaria(string IN_COD_DIS,
 string IN_ID_POSTE,
 string IN_SUBTIPO,
 string IN_CODIGOESTRUCTURA,
 string IN_CODIGOELEMENTO,
 string IN_ROTACIONSIMBOLO,
 string IN_FASECONEXION,
 string IN_TIPO_RED,
 string IN_REUBICADO,
 string IN_COOR_X,
 string IN_COOR_Y,
 string IN_OBSERVACIONES,
 string IN_ESTADO)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            List<string> varListRegistros = new List<string>();
            /*string varSubtipo = string.Empty;
            string varauxsubtipo = IN_CODIGOESTRUCTURA.Substring(0, 1);
            switch (varauxsubtipo)
            {
                case "L":

                    string varauxsubtipo2 = IN_CODIGOESTRUCTURA.Substring(3, 1);
                    string varauxsubtipo3 = IN_CODIGOESTRUCTURA.Substring(IN_CODIGOESTRUCTURA.Length - 1, 1);
                    switch (varauxsubtipo2 + varauxsubtipo3)
                    {

                        case "SC":
                            varSubtipo = "4";


                            break;

                        case "SA":
                            varSubtipo = "3";


                            break;

                        case "MC":
                            varSubtipo = "2";


                            break;

                        case "MA":
                            varSubtipo = "1";


                            break;
                    }

                    break;
                case "P":
                    string varauxsubtipop = IN_CODIGOESTRUCTURA.Substring(3, 1);
                    switch (varauxsubtipop)
                    {
                        case "S":
                            varSubtipo = "6";



                            break;
                        case "M":
                            varSubtipo = "7";


                            break;
                    }
                    break;

                case "A":
                    string varauxsubtipoo = IN_CODIGOESTRUCTURA.Substring(1, 1);
                    switch (varauxsubtipoo)
                    {
                        case "O":
                            varSubtipo = "8";
                            break;
                        case "P":
                            varSubtipo = "9";
                            break;
                    }


                    break;

                default:

                    MessageBox.Show("Codigo estructura de luminaria no codificado" + IN_CODIGOESTRUCTURA);

                    break;



            }
            */

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_LUMINARIA";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_COD_DIS", OracleType.VarChar).Value = IN_COD_DIS;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO", OracleType.VarChar).Value = IN_CODIGOELEMENTO;
                objCmd.Parameters.Add("IN_ROTACIONSIMBOLO", OracleType.VarChar).Value = IN_ROTACIONSIMBOLO;
                objCmd.Parameters.Add("IN_FASECONEXION", OracleType.VarChar).Value = IN_FASECONEXION;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = IN_TIPO_RED;
                objCmd.Parameters.Add("IN_REUBICADO", OracleType.VarChar).Value = IN_REUBICADO;
                objCmd.Parameters.Add("IN_COOR_X", OracleType.VarChar).Value = IN_COOR_X;
                objCmd.Parameters.Add("IN_COOR_Y", OracleType.VarChar).Value = IN_COOR_Y;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;

                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_LUMINARIAS"].ToString() + "^" +
                                objReader["COD_DIS"].ToString() + "^" +
                                objReader["ID_POSTE"].ToString() + "^" +
                                objReader["SUBTIPO"].ToString() + "^" +
                                objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                                objReader["CODIGOELEMENTO"].ToString() + "^" +
                                objReader["ROTACIONSIMBOLO"].ToString() + "^" +
                                objReader["FASECONEXION"].ToString() + "^" +
                                objReader["TIPO_RED"].ToString() + "^" +
                                objReader["REUBICADO"].ToString() + "^" +
                                objReader["COOR_X"].ToString() + "^" +
                                objReader["COOR_Y"].ToString() + "^" +
                                objReader["OBSERVACIONES"].ToString() + "^" +
                                objReader["ESTADO"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }


        //insert Tensores

        public List<string> InsertTensor(string IN_ID_POSTE,
  string IN_SUBTIPO,
  string IN_CODIGOESTRUCTURA,
  string IN_ROTACIONSIMBOLO,
  string IN_ESTADO,
  string IN_OBSERVACIONES)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            List<string> varListRegistros = new List<string>();

            /*
            string varSubtipoTensor = string.Empty;
            string varauxsubtipotensor = IN_CODIGOESTRUCTURA.ToString().Substring(0, 1);
            switch (varauxsubtipotensor)
            {
                case "T":


                    string varauxsubtipotensor2 = IN_CODIGOESTRUCTURA.ToString().Substring(1, 1);
                    switch (varauxsubtipotensor2)
                    {
                        case "T":
                            string varauxsubtipotensor3 = IN_CODIGOESTRUCTURA.ToString().Substring(2, 1);
                            switch (varauxsubtipotensor3)
                            {

                                case "D":
                                    varSubtipoTensor = "7";

                                    break;
                                case "S":

                                    string varauxsubtipo4 = IN_CODIGOESTRUCTURA.ToString().Substring(IN_CODIGOESTRUCTURA.ToString().Length - 1, 1);
                                    switch (varauxsubtipo4)
                                    {
                                        case "D":

                                            varSubtipoTensor = "1";
                                            break;
                                        case "T":

                                            varSubtipoTensor = "2";
                                            break;
                                    }



                                    break;
                            }

                            break;
                        case "F":
                            string varauxsubtipotensorf3 = IN_CODIGOESTRUCTURA.ToString().Substring(2, 1);
                            switch (varauxsubtipotensorf3)
                            {

                                case "D":
                                    varSubtipoTensor = "8";

                                    break;
                                case "S":

                                    string varauxsubtipof4 = IN_CODIGOESTRUCTURA.ToString().Substring(IN_CODIGOESTRUCTURA.ToString().Length - 1, 1);
                                    switch (varauxsubtipof4)
                                    {
                                        case "D":
                                            varSubtipoTensor = "3";

                                            break;
                                        case "T":

                                            varSubtipoTensor = "4";
                                            break;
                                        case "V":

                                            varSubtipoTensor = string.Empty;
                                            break;
                                        case "S":
                                            varSubtipoTensor = string.Empty;
                                            break;
                                    }


                                    break;
                            }
                            break;
                        case "V":
                            varSubtipoTensor = string.Empty;
                            break;
                        case "E":
                            string varauxsubtipotensore3 = IN_CODIGOESTRUCTURA.ToString().Substring(2, 1);
                            switch (varauxsubtipotensore3)
                            {


                                case "S":

                                    string varauxsubtipoe4 = IN_CODIGOESTRUCTURA.ToString().Substring(IN_CODIGOESTRUCTURA.ToString().Length - 1, 1);
                                    switch (varauxsubtipoe4)
                                    {
                                        case "D":

                                            varSubtipoTensor = "10";
                                            break;
                                        case "T":

                                            varSubtipoTensor = "11";
                                            break;
                                        case "V":

                                            varSubtipoTensor = string.Empty;
                                            break;
                                        case "S":
                                            varSubtipoTensor = string.Empty;
                                            break;
                                    }
                                    break;
                            }


                            break;
                        case "P":
                            string varauxsubtipotensorp3 = IN_CODIGOESTRUCTURA.ToString().Substring(2, 1);
                            switch (varauxsubtipotensorp3)
                            {

                                case "D":

                                    varSubtipoTensor = "9";
                                    break;
                                case "S":

                                    string varauxsubtipop4 = IN_CODIGOESTRUCTURA.ToString().Substring(IN_CODIGOESTRUCTURA.ToString().Length - 1, 1);
                                    switch (varauxsubtipop4)
                                    {
                                        case "D":

                                            varSubtipoTensor = "4";
                                            break;
                                        case "T":

                                            varSubtipoTensor = "6";
                                            break;
                                        case "V":
                                            varSubtipoTensor = string.Empty;
                                            break;
                                        case "S":
                                            varSubtipoTensor = string.Empty;
                                            break;
                                    }


                                    break;
                            }
                            break;
                    }
                    break;

            }
            */


            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_TENSOR";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = IN_SUBTIPO;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_ROTACIONSIMBOLO", OracleType.VarChar).Value = IN_ROTACIONSIMBOLO;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;

                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["ID_TENSOR"].ToString() + "," +
                                objReader["ID_POSTE"].ToString() + "," +
                                objReader["SUBTIPO"].ToString() + "," +
                                objReader["CODIGOESTRUCTURA"].ToString() + "," +
                                objReader["ROTACIONSIMBOLO"].ToString() + "," +
                                 objReader["ESTADO"].ToString() + "," +
                                objReader["OBSERVACIONES"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //Insert estructuras en poste

        public List<string> InsertEstructurasPoste(string IN_ID_POSTE, string IN_CODIGOESTRUCTURA, string IN_CANTIDAD, string IN_ESTADO, string IN_OBSERVACIONES)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_INSERT_SD_ESTRUCTURAENPOSTE";
                objCmd.CommandType = CommandType.StoredProcedure;

                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = IN_ID_POSTE;
                objCmd.Parameters.Add("IN_CODIGOESTRUCTURA", OracleType.VarChar).Value = IN_CODIGOESTRUCTURA;
                objCmd.Parameters.Add("IN_CANTIDAD", OracleType.VarChar).Value = IN_CANTIDAD;
                objCmd.Parameters.Add("IN_ESTADO", OracleType.VarChar).Value = IN_ESTADO;
                objCmd.Parameters.Add("IN_OBSERVACIONES", OracleType.VarChar).Value = IN_OBSERVACIONES;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;

                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_ESTR_POST"].ToString() + "," +
                                objReader["ID_POSTE"].ToString() + "," +
                                objReader["CODIGOESTRUCTURA"].ToString() + "," +
                                objReader["CANTIDAD"].ToString() + "," +
                                objReader["ESTADO"].ToString() + "," +
                                objReader["OBSERVACIONES"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }

        //funcion de login sistema
        public List<string> Login(string varUsuario, string varContra)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_ADMIN.PROC_SD_USUARIOS_LOGIN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_VAR_USUARIO", OracleType.VarChar).Value = varUsuario;
                objCmd.Parameters.Add("IN_VAR_CLAVE", OracleType.VarChar).Value = varContra;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;

                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {

                    vardatos = objReader["ID_USUARIO"].ToString() + "," +
                               objReader["USER_NAME"].ToString() + "," +
                               objReader["PASSWORD"].ToString() + "," +
                               objReader["NOMB_USUARIO"].ToString() + "," +
                               objReader["APE_USUARIO"].ToString() + "," +
                               objReader["COD_DEPARTAMENTO"].ToString() + "," +
                               objReader["COD_PERFIL"].ToString() + "," +
                               objReader["BLOQUEADO"].ToString() + "," +
                               objReader["ELIMINADO"].ToString();
                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return varListRegistros;
            }

            conn.Close();
            return varListRegistros;
        }



        //consulta dominio combos
      

        //lista de estructuras 

        public List<string> ConsultaListaEstructuras(string varDescClase)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTRUCTURAS_LISTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_DESC_CLASE", OracleType.VarChar).Value = varDescClase;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["CODIGOESTRUCTURA"].ToString() + "," +
                        objReader["COD_UNIDAD"].ToString() + "," +
                        objReader["CODI_CLAS"].ToString() + "," +
                        objReader["ID_CLAS_MO"].ToString() + "," +
                        objReader["DESCRIPCIONCORTA"].ToString() + "," +
                        objReader["DESCRIPCIONLARGA"].ToString() + ", " +
                         objReader["POTENCIA"].ToString() + "," +
                        objReader["TIPO_MAT"].ToString() + "," +
                        objReader["PRIORIDAD_ESTR"].ToString() + "," +
                        objReader["TIPO_ESTR"].ToString() + "," +
                        objReader["NIVEL_VOLTAJE_ESTR"].ToString() + "," +
                         objReader["PRECIO_ESTR"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }




        public List<string> ConsultaListaItemsCombosTrafos(string varSubipoId, string varCampo)
        {

            string vardatos = string.Empty;
            List<string> varListItems = new List<string>();


            OracleConnection conn = Exportables_Sisde.ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA.PROC_DOMINIO_ITEMS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_SUBTIPO", OracleType.VarChar).Value = varSubipoId;
                objCmd.Parameters.Add("IN_NOMB_CAMPO", OracleType.VarChar).Value = varCampo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;

                conn.Open();

                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {
                    vardatos = objReader["CODIGO"].ToString() + "," +objReader["DESCRIP"].ToString();
                    varListItems.Add(vardatos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("## ERROR: " + ex.Message);
                conn.Close();
                return varListItems;
            }
            conn.Close();
            return varListItems;
        }

        //fin de lista de estructuras
        //consulta pararrayos
        public List<string> ConsultaPararrayos(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_PARARRAYOS_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_PARARAYOS"].ToString() + "," +
                        objReader["ID_POSTE"].ToString() + "," +
                        objReader["SUBTIPO"].ToString() + "," +
                        objReader["CODIGOESTRUCTURA"].ToString() + "," +
                        objReader["ESTADO"].ToString() + "," +
                        objReader["OBSERVACIONES"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }

        //fin de pararrayos

        //consulta sec fusible
        public List<string> ConsultaSecFusible(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_PUESTOSECCIONADORFUSIBLE_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        vardatos = objReader["ID_PUEST_SEC_FUS"].ToString() + "^" +
                        objReader["ID_POSTE"].ToString() + "^" +
                        objReader["SUBTIPO"].ToString() + "^" +
                        objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                        objReader["CODIGOPUESTO"].ToString() + "^" +
                        objReader["FASECONEXION"].ToString() + "^" +
                         objReader["VOLTAJE"].ToString() + "^" +
                        objReader["POSICIONNORMAL_A"].ToString() + "^" +
                        objReader["POSICIONNORMAL_B"].ToString() + "^" +
                        objReader["POSICIONNORMAL_C"].ToString() + "^" +
                        objReader["POSICIONACTUAL_A"].ToString() + "^" +
                         objReader["POSICIONACTUAL_B"].ToString() + "^" +
                         objReader["POSICIONACTUAL_C"].ToString() + "^" +
                        objReader["CORRIENTE"].ToString() + "^" +
                         objReader["TIRAFUSIBLE"].ToString() + "^" +
                         objReader["TIPO"].ToString() + "^" +
                        objReader["CORRIENTEMAXCORTOCIRCUITO"].ToString() + "^" +
                         objReader["TIPO_RED"].ToString() + "^" +
                         objReader["REUBICADO"].ToString() + "^" +
                        objReader["COOR_X"].ToString() + "^" +
                         objReader["COOR_Y"].ToString() + "^" +
                         objReader["OBSERVACIONES"].ToString() + "^" +
                        objReader["ESTADO"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }



        //fin sec fusible


        //consulta sec cuchilla
        public List<string> ConsultaSecCuchilla(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_PUESTOSECCIONADOR_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_PUEST_SEC_CUCHI"].ToString() + "^" +
                        objReader["ID_POSTE"].ToString() + "^" +
                        objReader["SUBTIPO"].ToString() + "^" +
                        objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                        objReader["CODIGOPUESTO"].ToString() + "^" +
                        objReader["FASECONEXION"].ToString() + "^" +
                         objReader["VOLTAJE"].ToString() + "^" +
                        objReader["POSICIONNORMAL_A"].ToString() + "^" +
                        objReader["POSICIONNORMAL_B"].ToString() + "^" +
                        objReader["POSICIONNORMAL_C"].ToString() + "^" +
                        objReader["POSICIONACTUAL_A"].ToString() + "^" +
                         objReader["POSICIONACTUAL_B"].ToString() + "^" +
                         objReader["POSICIONACTUAL_C"].ToString() + "^" +
                        objReader["CORRIENTE"].ToString() + "^" +
                         objReader["CORRIENTE_3F_CIRCUITO"].ToString() + "^" +
                         objReader["CORRIENTE_1F_CIRCUITO"].ToString() + "^" +
                        objReader["CORRIENTEMAXCORTOCIRCUITO"].ToString() + "^" +
                         objReader["TIPO_RED"].ToString() + "^" +
                         objReader["REUBICADO"].ToString() + "^" +
                        objReader["COOR_X"].ToString() + "^" +
                         objReader["COOR_Y"].ToString() + "^" +
                         objReader["OBSERVACIONES"].ToString() + "^" +
                        objReader["ESTADO"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }


        //fin sec cuchilla

        //consulta trafos

        public List<string> ConsultaTrafos(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_PUESTOTRANSFDISTRIBUCION_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_PUEST_TRANSF"].ToString() + '^' +
                        objReader["GID_POSTE"].ToString() + '^' +
                        objReader["COD_DIS"].ToString() + '^' +
                        objReader["SUBTIPO"].ToString() + '^' +
                        objReader["CODIGOESTRUCTURA"].ToString() + '^' +
                        objReader["CODIGOPUESTO"].ToString() + '^' +
                         objReader["FASECONEXION"].ToString() + '^' +
                        objReader["VOLTAJE"].ToString() + '^' +
                        objReader["POTENCIAKVA"].ToString() + '^' +
                        objReader["CONFIGURACIONLADOBAJA"].ToString() + '^' +
                        objReader["TRAFO"].ToString() + '^' +
                         objReader["PROPIEDAD"].ToString() + '^' +
                         objReader["ESTADO"].ToString() + '^' +
                        objReader["VOLTAJESECUNDARIO"].ToString() + '^' +
                         objReader["CONFIGURACIONLADOMEDIA"].ToString() + '^' +
                         objReader["TIPO_TRAFO"].ToString() + '^' +
                        objReader["TIPO_USO_RED"].ToString() + '^' +
                         objReader["TIPO_RED"].ToString() + '^' +
                         objReader["REUBICADO"].ToString() + '^' +
                        objReader["COOR_X"].ToString() + '^' +
                         objReader["COOR_Y"].ToString() + '^' +
                        objReader["OBSERVACIONES"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }


        //fin consulta trafos

        //consulta luminarias



        public List<string> ConsultaLuminarias(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_LUMINARIA_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_LUMINARIAS"].ToString() + "^" +
                        objReader["COD_DIS"].ToString() + "^" +
                        objReader["ID_POSTE"].ToString() + "^" +
                        objReader["SUBTIPO"].ToString() + "^" +
                        objReader["CODIGOESTRUCTURA"].ToString() + "^" +
                        objReader["CODIGOELEMENTO"].ToString() + "^" +
                         objReader["ROTACIONSIMBOLO"].ToString() + "^" +
                        objReader["FASECONEXION"].ToString() + "^" +
                        objReader["TIPO_RED"].ToString() + "^" +
                        objReader["REUBICADO"].ToString() + "^" +
                        objReader["COOR_X"].ToString() + "^" +
                         objReader["COOR_Y"].ToString() + "^" +
                         objReader["OBSERVACIONES"].ToString() + "^" +
                        objReader["ESTADO"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }

        //fin de consulta luminarias


        //consulta tensores

        public List<string> ConsultaTensores(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_TENSORES_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_TENSOR"].ToString() + "," +
                        objReader["ID_POSTE"].ToString() + "," +
                        objReader["SUBTIPO"].ToString() + "," +
                        objReader["CODIGOESTRUCTURA"].ToString() + "," +
                        objReader["ROTACIONSIMBOLO"].ToString() + "," +
                        objReader["ESTADO"].ToString() + "," +
                        objReader["OBSERVACIONES"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }


        //CONSULTA ESTRUCTURAS EN POSTE


        public List<string> ConsultaEstructurasPoste(string varIdposte)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListEstructuras = new List<string>();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_ESTRUCTURAENPOSTE_CONSULTA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_ID_POSTE", OracleType.VarChar).Value = varIdposte;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_ESTR_POST"].ToString() + "," +
                        objReader["ID_POSTE"].ToString() + "," +
                        objReader["CODIGOESTRUCTURA"].ToString() + "," +
                        objReader["CANTIDAD"].ToString() + "," +
                        objReader["ESTADO"].ToString() + "," +
                        objReader["OBSERVACIONES"].ToString();
                        varListEstructuras.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListEstructuras.Add("ERROR," + ex.Message);
                return varListEstructuras;
            }

            conn.Close();
            return varListEstructuras;

        }

        //FIN DE CONSULTA ESTRUCTURAS EN POSTE

        public string ConsultaInfoPoste(string varcodigo, string vartipored)
        {
            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_CONSULTAPOSTE";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_CODIGOELEMENTO", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("IN_TIPO_RED", OracleType.VarChar).Value = vartipored;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        vardatos = objReader["ID_POSTE"].ToString() + "," +
                        objReader["COD_DIS"].ToString() + "," +
                        objReader["SUBTIPO"].ToString() + "," +
                        objReader["CODIGOESTRUCTURA"].ToString() + "," +
                        objReader["CODIGOELEMENTO"].ToString() + "," +
                        objReader["TIPOCIMIENTO"].ToString() + "," +
                        objReader["ATERRAMIENTO"].ToString() + "," +
                        objReader["ESTADO"].ToString() + "," +
                        objReader["PROPIEDAD"].ToString() + "," +
                        objReader["TIPOUSOPOSTE"].ToString() + "," +
                        objReader["REUBICADO"].ToString() + "," +
                        objReader["USO_GRUA"].ToString() + "," +
                        objReader["TIPO_RED"].ToString() + "," +
                        objReader["COORD_X"].ToString() + "," +
                        objReader["COORD_Y"].ToString() + "," +
                        objReader["OBSERVACIONES"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                return "ERROR," + ex.Message;
            }

            conn.Close();
            return vardatos;

        }

        //inicio consulta materiales de poste

        public List<string> ConsultaMatEstructuraSoporte(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "ESTRSOPORTE";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }

        //inicio materiales de la estructura
        public List<string> ConsultaMatEstructura(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "ESTRUCTURAS";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }

        //inicio materiales de tensores
        public List<string> ConsultaMatTensor(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "TENSOR";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }
        //inicio materiales de luminaria
        public List<string> ConsultaMatLuminaria(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "LUMINARIA";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }
        //inicio materiales de trafo
        public List<string> ConsultaMatTrafo(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "TRAFO";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }
        //inicio materiales de seccionador
        public List<string> ConsultaMatSeccionador(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "SECCIONADOR";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }
        //inicio materiales de seccionador fusible
        public List<string> ConsultaMatSeccionadorFusible(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "SECCIONADORFUS";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }
        //inicio materiales de seccionador fusible
        public List<string> ConsultaMatPararrayo(string varcodigo)
        {
            string vardatos = string.Empty;
            List<string> varListMateriales = new List<string>();
            OracleConnection conn = ConnOra.GetDBConnection();
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = conn;
                objCmd.CommandText = "PKG_SISTEMA.PROC_SD_MAT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("IN_FEATURE", OracleType.VarChar).Value = "PARARRAYO";
                objCmd.Parameters.Add("IN_VALUE_ID", OracleType.VarChar).Value = varcodigo;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        vardatos = objReader["ID_MAT"].ToString() + "¬" +
                        objReader["ID_OBJECT"].ToString() + "¬" +
                        objReader["COD_MAT"].ToString() + "¬" +
                        objReader["CANTIDAD_MAT"].ToString() + "¬" +
                        objReader["CALIF_MAT"].ToString();
                        varListMateriales.Add(vardatos);
                    }
                }

            }
            catch (Exception ex)
            {
                varListMateriales.Add("ERROR," + ex.Message);
                return varListMateriales;
            }

            conn.Close();
            return varListMateriales;

        }

        //funcion consulta MAC ADDRESS EN DB

        public Int16 cons_mac_address(string IN_mac)
        {
            OracleConnection conn = ConnOra.GetDBConnection();
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            string strQuery = string.Empty;
            Int16 varMAC = -1;
            try
            {
                strQuery = "select PKG_SISTEMA2.F_MAC_ADDRESS('" + IN_mac + "') AS MAC from dual";
                objCmd.CommandText = strQuery;
                objCmd.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
                objReader = objCmd.ExecuteReader();
                //if (objReader.HasRows)
                //{
                while (objReader.Read())
                {
                    if (objReader["MAC"] != DBNull.Value)
                    {
                        varMAC = Convert.ToInt16(objReader["MAC"].ToString());
                    }
                    else
                    {
                        varMAC = -1;
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR," + ex.Message);
                return -1;
            }

            conn.Close();
            return varMAC;
        }

        //INSERTA MAC EN DB
        public string InsertMacAddress(string IN_MACADDRESS)
        {

            string vardatos = string.Empty;
            OracleConnection conn = ConnOra.GetDBConnection();

            List<string> varListRegistros = new List<string>();

            try
            {
                OracleCommand objCmd = new OracleCommand();

                objCmd.Connection = conn;

                objCmd.CommandText = "PKG_SISTEMA2.PR_INSERT_MAC_ADDRESS";
                objCmd.Parameters.Add("IN_MAC", OracleType.VarChar).Value = IN_MACADDRESS;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("RESPUESTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();

                while (objReader.Read())
                {


                    vardatos = objReader["MAC_INSERT"].ToString() ;

                    varListRegistros.Add(vardatos);

                }
            }
            catch (Exception ex)
            {
                varListRegistros.Add("ERROR," + ex.Message);
                return vardatos;
            }

            conn.Close();
            return vardatos;
        }


        //funcion consulta ESTRUCTURA (CODIGO CORTO) SI EXISTE EN DB Y ESTA CONFORMADA

        public Int16 validaEstr(string inEstr)
        {
            OracleConnection conn = ConnOra.GetDBConnection();
            OracleCommand objCmd = new OracleCommand();
            objCmd.Connection = conn;
            string strQuery = string.Empty;
            Int16 existe = -1;
            try
            {
                strQuery = "select PKG_SISTEMA2.F_VALIDA_ESTR('" + inEstr + "') AS valExiste from dual";
                objCmd.CommandText = strQuery;
                objCmd.CommandType = CommandType.Text;
                conn.Open();
                OracleDataReader objReader = objCmd.ExecuteReader();
                objReader = objCmd.ExecuteReader();
                //if (objReader.HasRows)
                //{
                while (objReader.Read())
                {
                    existe = Convert.ToInt16(objReader["valExiste"]);
                }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR," + ex.Message);
                return -1;
            }

            conn.Close();
            return existe;
        }

    }
}
