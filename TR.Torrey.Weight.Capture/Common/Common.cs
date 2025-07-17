using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TR.Torrey.Weight.Capture.Common
{
    public class Common
    {
        /*
        |--------------------------------------------------
        | PATH
        |--------------------------------------------------
        */
        public static string DATABASE_PATH = "Dao/torrey_weigh.db";
        public static string IMAGE_DEFAULT_PATH = "/Resources/placeholder.jpg";


        public static string DB_TABLE_SCALE = "tcScale";



        public static int ID_ZERO = 0;
        public static int ID_ONE = 1;
        public static string SCALE_IP_DEFAULT = "0.0.0.0";


        /*
        |--------------------------------------------------
        | RESPONSE MESSAGE
        |--------------------------------------------------
        */
        public static string MSG_SCALE_SAVE_SUCCESS = "Báscula guardada con exito";
        public static string MSG_SCALE_DELETE_SUCCESS= "Báscula eliminada con exito";
        public static string MSG_SCALE_SAVE_ERROR   = "Error al guardar la información de la báscula";
        public static string MSG_SCALE_GET          = "Mostrando básculas almacenadas";
        public static string MSG_SHOWING_ITEM       = "Mostrando";
        public static string MSG_OF_ITEM            = "de";
        public static string MSG_SEARCH             = "Buscar..";
        public static string MSG_SCALE_ADD          = "Agregar";
        public static string MSG_SCALE              = "Báscula";
        public static string MSG_SCALE_IP           = "Ip";
        public static string MSG_SCALE_NOT_FOUND    = "No se encontraron básculas en el sistema";
        public static string MSG_CREATE_REPORT      = "Reiniciar y generar reporte";
        public static string MSG_REPORT             = "Reporte";
        public static string MSG_REPORT_SAVED       = "Reporte guardado en:";
        //EXCEPTION
        public static string EXCEPTION_RETRY        = "Conectando ...";
        public static string EXCEPTION_DISCONNECT   = "Báscula desconectada";

        public static string MSG_EDIT               = "Editar";
        public static string MSG_DELETE             = "Eliminar";
        public static string MSG_NAME               = "Nombre";
        public static string MSG_IP                 = "Ip";
        public static string MSG_MINWEIGHT          = "Peso minimo";
        public static string MSG_STATUS             = "Estatus";
        public static string MSG_LASTUPDATE         = "Ultima actualización";
        public static string MSG_MINTIME            = "Tiempo minimo";
        public static string MSG_ACTIONS            = "Acciones";
        public static string MSG_WEIGHT             = "Peso";
        public static string MSG_DATE               = "Fecha";
        public static string MSG_TOTAL              = "Total";
        public static string MSG_SAMPLES            = "Muestras";
        public static string MSG_SAVE               = "Guardar";
        public static string MSG_CLOSE              = "Cerrar";
        public static string MSG_ERROR_NAME         = "Ingrese un nombre para la báscula";
        public static string MSG_ERROR_IP           = "Ingrese la ip de la báscula";
        public static string MSG_ERROR_MINWEIGHT    = "Ingrese el rango mínimo de peso \ncon el que se contabilizarán los registros";
        public static string MSG_ERROR_MINTIME      = "Ingrese el tiempo mínimo para \nla captura de muestras";
        public static string MSG_ERROR_READ_SCALE   = "Error en la lectura de básculas";
        public static string MSG_ERROR_DISCONNECT   = "Error al cerrar la comunicación con las básculas";
        public static string MSG_ERROR_SAVE_WEIGHT  = "Error al guardar peso";
        public static string MSG_ERROR_CREATE_REPORT= "Error al generar reporte";

        public static string MSG_VERSION            = "Ver. 1.1.0";

        public static int MODE_WIFI                 = 1;
        public static int MODE_SERIAL               = 2;
        public static int SCALE_PORT                = 22;

        /*
        |--------------------------------------------------
        | RESPONSE CODES
        |--------------------------------------------------
        */
        public static int CODE_SYNC = 1;
        public static int CODE_UPDATED = 2;
        public static int CODE_ERROR = 3;
        public static int CODE_NO_DATA = 4;
        public static int CODE_CREATED = 5;
        public static int CODE_SUCCESS = 6;
        public static int CODE_EMAIL_EXIST = 7;
        public static int CODE_USER_EXIST = 8;
        public static int CODE_DEVICE_NO_CREATED = 9;
        public static int CODE_DEVICE_NO_USER = 10;
        public static int CODE_PRODUCT_CODE_EXIST = 11;
        public static int CODE_PRODUCT_PLU_EXIST = 12;
        public static int CODE_STORE_EXIST_DEPARTMENTS = 13;
        public static int CODE_DEPARTMENT_EXIST_DEVICES = 14;
        public static int CODE_DEPARTMENT_EXIST_PRODUCTS = 15;
        public static int CODE_DEVICE_EXIST_DEPARTMENTS = 16;
        public static int CODE_EMAIL_NO_EXIST = 17;
        public static int CODE_NO_VALID_KEY = 18;
        public static int CODE_UNAUTHORIZED_USER = 19;
        public static int CODE_AUDITORY_IN_PROGRESS = 20;
        public static int CODE_AUDITORY_PENDING_CODES = 21;
        public static int CODE_USER_MASTER_EXIST = 22;

        public static int CODE_SERVER_NOT_FOUND = 101;

        public const string ERROR_NOT_SCALE = "THIS DEVICE IS NOT A SCALE";
    }
}
