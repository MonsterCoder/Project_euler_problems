defmodule Triangular do
  # this method is not needed in this solution, just used to prove f(n) = n * (n+1) / 2
  def generate do
    Stream.unfold(1, &({(&1 * (&1+1))  |> div(2), &1 +1}))
  end

  def run(leng) do
    Stream.unfold(1, &({&1, &1+1}))
    |> Stream.map(&cal_length/1)
    |> Enum.find_index(&(&1 > leng))
    |> (fn(idx) -> (idx+1) *(idx+2) |> div(2) end).()
  end
  
  def cal_length(1), do: 1

  def cal_length(i) when rem(i,2)==0  do
    p1 = (Factor.of(div(i,2)) |> length) -1
    p2 = Factor.of(i+1) |> length

    p1+p2 + (p2-1) * p1
  end


  def cal_length(i) do
    p1 = Factor.of(i) |> length
    p2 = (Factor.of(div(i+1, 2)) |> length) -1
    p1+p2 + (p1-1) * p2 
  end
end

defmodule Factor do
    def of(1), do: [1]
    def of(n) do
      1..n 
      |> Enum.filter(&(rem(n, &1)==0))
    end
end
