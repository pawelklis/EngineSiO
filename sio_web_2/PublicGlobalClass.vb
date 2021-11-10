Public Class PublicGlobalClass
    Public Shared Function ShowTableFilter(dgName As String, filterNumber As Integer, popupfilters As Boolean, Optional dgColumnsCount As Integer = 1) As String
        '        Dim s As String = "
        '     <script src='../tablefilter/tablefilter.js'></script>
        '<script>

        '           var filtersConfig = {
        '            // instruct TableFilter location to import ressources from
        '            base_path: '../tablefilter/',


        '            alternate_rows: true,
        '            rows_counter: true,
        '            btn_reset: true,
        '            loader: true,
        '            mark_active_columns: true,
        '            highlight_keywords: false,
        '            no_results_message: true,
        '            popup_filters: " & popupfilters.ToString.ToLower & ",




        '            extensions: [{ name: 'sort' }]


        '        };

        '        var tf" & filterNumber & " = new TableFilter('" & dgName & "', filtersConfig);
        '        tf" & filterNumber & ".init();
        '    </script>"


        Dim sb As New StringBuilder
        sb.Append("
     <script src='../tablefilter/tablefilter.js'></script>
<script>

           var filtersConfig = {
            // instruct TableFilter location to import ressources from
            base_path: '../tablefilter/',
  
sticky_headers: true,
            alternate_rows: true,
            rows_counter: true,
            btn_reset: true,
            loader: true,
            mark_active_columns: true,
            highlight_keywords: true,
            no_results_message: true,
            popup_filters: " & popupfilters.ToString.ToLower & ",
")


        sb.AppendLine("  
          col_types: [")



        For i = 1 To dgColumnsCount
            If i < dgColumnsCount Then
                sb.AppendLine("'string',")
            Else
                sb.AppendLine("'string'")
            End If

        Next

        sb.AppendLine("  ],")

        sb.Append("

            extensions: [{ name: 'sort' }]


        };

        var tf" & filterNumber & " = new TableFilter('" & dgName & "', filtersConfig);
        tf" & filterNumber & ".init();
    </script>
")

        Return sb.ToString
    End Function
End Class
