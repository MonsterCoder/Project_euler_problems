defmodule Triangular2 do
  def generate2 do
    Stream.unfold(1, &({(&1 * (&1+1))  |> div(2), &1 +1}))
  end
end
