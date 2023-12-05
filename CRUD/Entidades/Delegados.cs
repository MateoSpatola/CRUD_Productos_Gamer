//Delegado para evento InicioSesionFallido en FrmLogin:
public delegate void DelegadoInicioSesionFallidoEventHandler(object sender, EventArgs e);

//Delegado para metodo ActualizarHoraEnTiempoReal en FrmPrincipal:
public delegate void DelegadoHoraEnTiempoReal<T>(T label);

//Delegado para metodo IncrementarBarraProgreso en FrmPrincipal:
public delegate void DelegadoIncrementarBarraProgreso<A, B, C>(A progressBar, B label1, C label2);

//Delegado para metodo FinalizarProcesoAcomodarProductos en FrmPrincipal:
public delegate void DelegadoFinalizarProceso<A, B>(A progressBar, B label);