export class Produto {
    nome: string;
    liberadoParaVenda: boolean;

    obterNome(): string {
        return this.nome;
    }
}