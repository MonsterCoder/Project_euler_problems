defmodule Triangular do
  def generate do
    Stream.unfold({0,1}, fn {acc, n} -> { acc+n, {acc+n, n+1} } end) 
  end

  def run(n) do
    generate
    |> Stream.filter(&(Factor.of(&1) |> length > n))
    |> Enum.at(0)
  end
end

defmodule Factor do
    def of(1), do: [1];
    def of(n) do
       1..n      
       |> Enum.filter(&(rem(n,&1)==0))
    end
end
