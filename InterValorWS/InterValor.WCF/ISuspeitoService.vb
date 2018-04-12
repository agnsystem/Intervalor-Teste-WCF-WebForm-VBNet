Imports System.ServiceModel
Imports System
Imports System.Linq
Imports System.Collections.Generic


' NOTE: You can use the "Rename" command on the context menu to change the interface name "ISuspeitoService" in both code and config file together.
<ServiceContract()>
Public Interface ISuspeitoService

    <OperationContract()>
    Function ListarTodos() As IEnumerable(Of Suspeito)

End Interface
