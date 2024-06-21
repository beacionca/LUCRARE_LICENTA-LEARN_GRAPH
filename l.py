import matplotlib.pyplot as plt
import networkx as nx
import os
import argparse

# Funcția pentru a citi graful cu ponderi și a-l desena într-un fișier imagine
def save_weighted_graph_as_image(filename, output_image,output_image1, bottom_text):
    G = nx.Graph()
    
    # Citim nodurile și ponderile din fișier
    with open(filename, 'r') as file:
        for line in file:
            if "neorientat" in line:
                break
            parts = line.strip().split()
            node1, node2, weight = parts[0], parts[1], float(parts[2])
            G.add_edge(node1, node2, weight=weight)
    
    # Ajustăm dimensiunile figurii
    plt.figure(figsize=(3, 2)) 
    
    # Alegem o poziție pentru noduri
    pos = nx.spring_layout(G)

    # Desenăm nodurile, muchiile și etichetele (cu ponderi)
    nx.draw(G, pos, with_labels=True, node_size=400, node_color='lightblue', font_size=8, font_weight='bold')
    edge_labels = nx.get_edge_attributes(G, 'weight')
    nx.draw_networkx_edge_labels(G, pos, edge_labels=edge_labels)
    # Adăugarea textului sub figura grafului 
    plt.figtext(0.5, 0.01, bottom_text, ha='center', fontsize=12)
    
    # Ajustăm layout-ul pentru a face spațiu pentru text
    plt.subplots_adjust(bottom=0.2)

    # Salvăm imaginea
    plt.savefig(output_image)
    plt.savefig(output_image1)


def find_last_file_created(directory):
    max_number = -1
    max_file = None

    for filename in os.listdir(directory):
        # Extragerea partii cu numărul din numele fișierului
        number_part = filename.rstrip('.txt')
        if number_part.isdigit():  # Verifică dacă extracția conține doar numere
            number = int(number_part)
            if number > max_number:
                max_number = number
                max_file = filename

    if max_file is not None:
        return max_file
    else:
        return "Niciun fișier valid găsit."
    
def find_last_variant_created(directory):
    max_number = -1

    for filename in os.listdir(directory):
        # Extragerea partii cu numărul din numele fișierului
        number_part = filename.rstrip('.txt')
        if number_part.isdigit():  # Verifică dacă extracția conține doar numere
            number = int(number_part)
            if number > max_number:
                max_number = number

    if max_number == -1:
        return "Niciun fișier valid găsit."
    else:
        return max_number


# Crearea unui ArgumentParser
parser = argparse.ArgumentParser(description="Script pentru a primi un string din linia de comandă")
    
# Adăugarea unui argument pentru string-ul de intrare
parser.add_argument('input_string', type=str, help='String-ul de intrare pentru script')
    
# Parsarea argumentelor din linia de comandă
args = parser.parse_args()
    
# Preluarea string-ului de intrare
input_string = args.input_string
    
# Afișarea string-ului primit
print(f"String-ul primit este: {input_string}")
data_folder1 = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_VALORI_NEORIENTATE/"
data_file1 = find_last_file_created(data_folder1)
data_complete_path1 = data_folder1 + data_file1

output_folder1 = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_IMAGINI_NEORIENTATE/"
output_file1 = str(find_last_variant_created(data_folder1)) + ".jpg"
output_complete_path1 = output_folder1 + output_file1

data_folder = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_VALORI/"
data_file = find_last_file_created(data_folder)
data_complete_path = data_folder + data_file

output_folder = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_IMAGINI/"
output_file = str(find_last_variant_created(data_folder)) + ".jpg"
output_complete_path = output_folder + output_file

save_weighted_graph_as_image(data_complete_path, output_complete_path,output_complete_path1, input_string)


