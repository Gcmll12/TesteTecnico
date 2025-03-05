// URL base da API
const Api_Url = 'https://localhost:7012/api/processos'; // Substitua pela URL completa do endpoint

// Função Get Processos
async function buscarProcessos() {
    try {
        const response = await fetch(Api_Url);

        if (!response.ok) {
            throw new Error("Erro ao Buscar Processos");
        }

        const processos = await response.json();
        alert(processos); // Apenas para testar

        exibirProcessos(processos);
    } catch (error) {
        console.error("Erro", error);
        document.getElementById("resultado").innerHTML = "Erro ao carregar os processos.";
    }
}

function exibirProcessos(processos) {
    const resultadoDiv = document.getElementById("resultado");
    resultadoDiv.innerHTML = "<h3>Lista de Processos:</h3>";

    processos.forEach(proc => {
        resultadoDiv.innerHTML += `
            <p><strong>Número do Processo:</strong> ${proc.numeroProcesso} | 
            <strong>Autor:</strong> ${proc.autor} | 
            <strong>Réu:</strong> ${proc.reu} | 
            <strong>Data de Cadastro:</strong> ${proc.dataCadastro}</p>
        `;
    });
}