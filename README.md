Uso de reportes en C#

Objeto de Estudio:

El objetivo principal es capacitar a los desarrolladores en la creación de reportes dinámicos y visualmente atractivos en aplicaciones C#. Cubriremos las herramientas y técnicas esenciales, permitiendo a los participantes generar informes personalizados para diversas necesidades empresariales.

Casos de Aprendizaje:

Reportes básicos con datos estáticos: Creación de reportes sencillos con información predefinida para comprender la estructura básica de un reporte.
Reportes con datos dinámicos desde bases de datos: Conexión a bases de datos (SQL Server, etc.) para generar reportes con información actualizada en tiempo real.
Reportes con parámetros: Implementación de filtros y parámetros para generar reportes personalizados según las necesidades del usuario.
Reportes con gráficos y tablas: Incorporación de elementos visuales para mejorar la presentación y comprensión de los datos.
Reportes con cálculos y fórmulas: Integración de cálculos matemáticos y lógicos dentro de los reportes, incluyendo cálculos financieros como el caso práctico que veremos.
El Uso de Reportes en C#:

Los reportes son cruciales en las aplicaciones empresariales para:

Análisis de datos: Presentar información clave de forma concisa y organizada para la toma de decisiones.
Seguimiento del rendimiento: Monitorear métricas y KPIs para evaluar el progreso y la eficiencia.
Cumplimiento normativo: Generar informes requeridos por regulaciones y estándares.
Comunicación interna y externa: Compartir información relevante con diferentes audiencias.
Herramientas para la Creación de Reportes en C#:

Existen diversas herramientas y bibliotecas para la creación de reportes en C#, entre las que destacan:

ReportViewer: Control integrado en Visual Studio que permite crear reportes utilizando archivos RDLC (Report Definition Language Client-side). Es una opción común y relativamente sencilla para reportes básicos y medianos.
Crystal Reports: Una solución robusta y completa para la creación de reportes complejos, con un diseñador visual potente y amplias opciones de personalización.
Caso Práctico: Cálculo Financiero de Préstamos Simples, Intereses y Amortizaciones:

Debe usar Programación orientada a objectos para la creación de las entidades y cálculos pertinentes.

Debe usar una separación en capas para que el código sea mas limpio y ordenado.

Puede usar una base de datos de su preferencia como SQL server, maría DB o PostgreSQL.

Debe tener un entorno visual agradable a la vista y fácil de entender.

Debe ser manejado con Git y GitHub.

Crear un programa en c# para la toma o adquisición de préstamos a una entidad financiera, la cual desea tener los registros de sus clientes, la entidad desea registrar información sobre sus clientes como nombre completo, correo, teléfono, dirección de residencia, el objecto ofrecido como garantía, y el sueldo que gana dicha persona.

las reglas del negocio son no dar prestamos superiores a 4 veces el sueldo de la persona.

No dar prestamos sin garantía

El interés se clasifica de acuerdo a la siguiente tabla de 12 meses se aplica un 13.25% de interés.

De 12 a 24 meses se aplica un 15% de interés.

De 24 meses en adelante se aplica un 30 % de interés. 

La entidad necesita registrar el monto de los préstamos de los clientes, el tiempo en meses de dichos prestamos, el interés generado, el monto total que es la suma de capital adquirido (monto) + interés.

La empresa tendrá un fondo base para préstamos de 10 millones de pesos.

La entidad no puede prestar dinero que no posee.

El cliente tiene derecho y puede ver su información personal y crediticia, puede modificar o actualizar su información personal mas no puede modificar las informaciones de los prestamos.

El cliente necesita ver la tabla de amortización de sus préstamos.

la entidad tendrá un formulario de pagos que contará con campos como el monto anterior, el interés a pagar, el nuevo monto a deber, la cuota, meses restantes, el total acumulado en Intereses, la taza de ese préstamo.

El monto a pagar es calculado y no modificable, y en caso de que no se pague ese mes se calcula una mora de un 10 % del monto a pagar en dicho mes. 

Si el cliente acumula un total de 3 moras durante un préstamo pasa a la lista de cliente morosos.

Este caso práctico se centrará en la creación de reportes como:

Reporte #1 calcule y muestre la tabla de amortización de un préstamo simple.

Reporte #2 muestre la información detallada de un cliente.

Reporte #3 muestre el total de dinero prestado, y el total de interés o ganancia total.

Reporte #4 muestre el total de moras acumuladas por los clientes. (cliente, Cantidad de Moras) 

Reporte #5 muestre un listado de los clientes morosos.

Este trabajo sera en grupos de 5 personas, y se calculara cada aporte de forma invidual.

Fórmulas que se suelen usar en el mundo financiero:

Interés Simple: I = P * r * t (donde I es el interés, P es el capital inicial, r es la tasa de interés y t es el tiempo). Se aplica cuando los intereses no se acumulan al capital.
Interés Compuesto: A = P (1 + r/n)^(nt) (donde A es el monto final, P es el capital inicial, r es la tasa de interés anual, n es el número de veces que se capitaliza  el interés al año y t es el tiempo en años). Se aplica cuando los intereses se acumulan al capital generando nuevos intereses.  
Cuota de un Préstamo (Sistema Francés/Cuota Fija): M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1] (donde M es la cuota mensual, P es el capital del préstamo, i es la tasa de interés mensual y n es el número de cuotas).
Ejemplo de Implementación (Código C# Conceptual con ReportViewer):

Obtener los datos del préstamo: Capital, tasa de interés anual, plazo en meses.
Calcular la cuota mensual (usando la fórmula).
Generar la tabla de amortización:
Para cada mes:
Calcular el interés del mes: Saldo anterior * tasa de interés mensual.
Calcular la amortización del capital: Cuota mensual – Interés del mes.
Calcular el nuevo saldo: Saldo anterior – Amortización del capital.
Crear un reporte RDLC con ReportViewer:
Definir un dataset con las columnas: Mes, Cuota, Interés, Amortización, Saldo.
Diseñar el reporte utilizando el diseñador de ReportViewer, vinculando los campos del dataset a los elementos visuales del reporte.
Llenar el dataset con los datos calculados y mostrar el reporte.
