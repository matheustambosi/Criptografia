> Este projeto é uma atividade da faculdade que tinha como objetivo compreender e implantar um software de criptografia de arquivos RSA.

## Como organizamos o projeto?

Separamos em 3 projetos, um é um console que criptografa, outro descriptrografa e outro chamamos de "Core", que foi onde centralizamos o nosso TextChunk, responsável pela lógica dos 2 programas anteriores.

## Como utilizar?

1) Clone o projeto e abra com a IDE de sua preferência, recomendamos que use o Visual Studio.

2) O projeto utiliza arquivos que ficam na pasta "Arquivos" que existe em cada projeto, portanto devemos clicar como botão direito em cada arquivo e copiar o diretório, devemos colocar nas respectivas linhas de codigo que utilizam estes arquivos.

* No Encriptador devemos substituir nas linhas (15, 18 e 37 e 49)
* No Descriptador devemos substituir nas linhas (14, 17, 41 e 44)

3) Após isso podemos rodar o programa, que se trata de um console application, após rodar, o arquivo "dest.txt" irá ser modificado (que é o resultado da nossa aplicação).

## Como testamos?

Foram testes manuais, colocamos breakpoint no codigo e acompanhamos o estado do arquivo.

## O que funcionou

Bom, nosso sistema de criptografia funcionou apenas nosso sistema de descriptografar que está com uma exception que não conseguimos resolver.

## Dificuldades

Tivemos diversos problemas na parte de Descriptografar, um deles não conseguimos corrigir, que é uma exception que é gerada na linha 38, onde pegamos a string que é um base64, que é o resultado do nosso TextChunk, a exception diz que a string não é um base64 válido, tentamos fazer umas alterações porem o erro se manteve.

# Conclusão

Bom, achei interessante o trabalho, pois, ja tinha utilizado biblioteca para fazer essa mesma criptografia porém não sabia o que acontecia "por tras", imagino que sim, valeu a pena justamente para compreender a lógica.

## Tecnologias

* .NET Core 3.1 em conjunto com C#, utilizamos esta linguagem, pois, ja temos um pouco de conhecimento por conta do trabalho.

## Autores

👤 **Matheus Tambosi e João Artur**

* Github: [@matheustambosi](https://github.com/matheustambosi), [@joaooartur](https://github.com/joaooartur)
