import matplotlib.pyplot as plt
import networkx as nx
import os
import argparse

def save_weighted_directed_graph_as_image(filename, output_image1, output_image2, bottom_text):
    G = nx.DiGraph() # Schimbăm în graf orientat

    # Citim nodurile și ponderile din fișier
    with open(filename, 'r') as file:
        for line in file:
            if "orientat" in line:
                break
            parts = line.strip().split()
            node1, node2, weight = parts[0], parts[1], float(parts[2])
            G.add_edge(node1, node2, weight=weight)

    # Ajustăm dimensiunile figurii
    plt.figure(figsize=(3, 2)) 

    # Alegem o poziție pentru noduri folosind shell_layout
    pos = nx.shell_layout(G)

    # Desenăm nodurile
    nx.draw(G, pos, with_labels=True, node_size=400, node_color='lightblue', font_size=8, font_weight='bold', arrows=True)

    # Verificăm și desenăm muchiile bidirecționale
    bidirectional_edges = []
    for node1, node2, data in G.edges(data=True):
        if G.has_edge(node2, node1):
            bidirectional_edges.append((node1, node2))

    for (node1, node2) in bidirectional_edges:
        # Desenăm ambele muchii cu o ușoară deplasare
        offset_pos = {node: (x + (0.05 if node in [node1, node2] else 0), y + (0.05 if node in [node1, node2] else 0)) for node, (x, y) in pos.items()}
    
        # Etichete pentru ambele direcții
        weight1 = G[node1][node2]['weight']
        weight2 = G[node2][node1]['weight']
        label_pos1 = (offset_pos[node1][0] * 0.7 + offset_pos[node2][0] * 0.3, offset_pos[node1][1] * 0.7 + offset_pos[node2][1] * 0.3)
        label_pos2 = (offset_pos[node2][0] * 0.7 + offset_pos[node1][0] * 0.3, offset_pos[node2][1] * 0.7 + offset_pos[node1][1] * 0.3)
        plt.text(label_pos1[0], label_pos1[1], s=f'{weight1}', bbox=dict(facecolor='white', edgecolor='none'), horizontalalignment='center', verticalalignment='center')
        plt.text(label_pos2[0], label_pos2[1], s=f'{weight2}', bbox=dict(facecolor='white', edgecolor='none'), horizontalalignment='center', verticalalignment='center')

    # Desenăm etichetele pentru muchiile care nu sunt bidirecționale
    single_direction_edges = [(u, v) for u, v in G.edges() if not G.has_edge(v, u)]
    edge_labels = {(u, v): data['weight'] for u, v, data in G.edges(data=True) if not G.has_edge(v, u)}
    nx.draw_networkx_edge_labels(G, pos, edge_labels=edge_labels)

    # Adăugarea textului sub figura grafului 
    plt.figtext(0.5, 0.01, bottom_text, ha='center', fontsize=12)

    # Ajustăm layout-ul pentru a face spațiu pentru text
    plt.subplots_adjust(bottom=0.2)

    # Salvăm imaginea
    plt.savefig(output_image1)
    plt.savefig(output_image2)
    plt.close()  # Închidem figura pentru a elibera memoria\



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
data_folder = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_VALORI_ORIENTATE/"
data_file = find_last_file_created(data_folder)
data_complete_path = data_folder + data_file

output_folder1 = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_IMAGINI_ORIENTATE/"
output_file1 = str(find_last_variant_created(data_folder)) + ".jpg"
output_complete_path1 = output_folder1 + output_file1

data_folder2 = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_VALORI/"
data_file2 = find_last_file_created(data_folder2)
data_complete_path2 = data_folder2 + data_file2

output_folder2 = "C:/Users/Beatrice/Desktop/AN III/semestru 2/LICENTA/GRAF_IMAGINI/"
output_file2 = str(find_last_variant_created(data_folder2)) + ".jpg"
output_complete_path2 = output_folder2 + output_file2

save_weighted_directed_graph_as_image(data_complete_path2, output_complete_path2, output_complete_path1, input_string)


