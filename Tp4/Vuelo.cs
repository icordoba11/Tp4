using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

[Serializable]
public class Vuelo
{
    public string Codigo { get; set; }
    public DateTime FechaHoraSalida { get; set; }
    public DateTime FechaHoraLlegada { get; set; }
    public string Piloto { get; set; }
    public string Copiloto { get; set; }
    public int CapacidadMaxima { get; set; }
    public int PasajerosRegistrados { get; set; }

    public double ObtenerOcupacion()
    {
        return (double)PasajerosRegistrados / CapacidadMaxima * 100;
    }

    public Vuelo() { }
    public Vuelo(string codigo, DateTime salida, DateTime llegada, string piloto, string copiloto, int capacidad)
    {
        Codigo = codigo;
        FechaHoraSalida = salida;
        FechaHoraLlegada = llegada;
        Piloto = piloto;
        Copiloto = copiloto;
        CapacidadMaxima = capacidad;
        PasajerosRegistrados = 0;
    }
}