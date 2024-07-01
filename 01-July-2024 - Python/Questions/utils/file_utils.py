from os import path
from pandas import DataFrame
from reportlab.lib.pagesizes import letter
from reportlab.platypus import SimpleDocTemplate, Table, TableStyle
from reportlab.lib import colors

def create_pdf_from_array(data: DataFrame, filename: str):

    if path.exists(filename):
        raise FileExistsError('File already exists, please delete it or rename it before creating a new one')

    pdf = SimpleDocTemplate("output/employees.pdf", pagesize=letter)

    table_data = []

    for i, row in data.iterrows():
        table_data.append(list(row))

    table = Table(table_data)

    table_style = TableStyle([
    ('BACKGROUND', (0, 0), (-1, 0), colors.grey),
    ('TEXTCOLOR', (0, 0), (-1, 0), colors.whitesmoke),
    ('ALIGN', (0, 0), (-1, -1), 'CENTER'),
    ('FONTNAME', (0, 0), (-1, 0), 'Helvetica-Bold'),
    ('FONTSIZE', (0, 0), (-1, 0), 14),
    ('BOTTOMPADDING', (0, 0), (-1, 0), 12),
    ('BACKGROUND', (0, 1), (-1, -1), colors.beige),
    ('TEXTCOLOR', (0, 1), (-1, -1), colors.black),
    ('ALIGN', (0, 1), (-1, -1), 'CENTER'),
    ('FONTNAME', (0, 1), (-1, -1), 'Helvetica'),
    ('FONTSIZE', (0, 1), (-1, -1), 12),
    ('BOTTOMPADDING', (0, 1), (-1, -1), 8),
    ])

    table.setStyle(table_style)

    pdf_table = []
    pdf_table.append(table)

    pdf.build(pdf_table)
    ...